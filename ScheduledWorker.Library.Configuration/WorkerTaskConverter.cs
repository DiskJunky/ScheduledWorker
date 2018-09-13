namespace ScheduledWorker.Library.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using Contracts;
    using Contracts.Logging;
    using Contracts.Schedule;
    using Contracts.Worker;

    /// <summary>
    /// This class is used to help convert a configuration setting value into a concrete
    /// instance that can be used for against the <see cref="IWorkerTask"/> interface.
    /// </summary>
    internal class WorkerTaskConverter : TypeConverter
    {
        #region Private Members        
        /// <summary>
        /// Holds a reference to the logging instance.
        /// </summary>
        private readonly ILogger _logger;
        #endregion

        #region TypeConverter Overrides
        /// <summary>
        /// This returns whether or not the converter can convert from the specified type.
        /// </summary>
        /// <param name="context">The context under which the conversion is happening.</param>
        /// <param name="sourceType">The source type to convert from.</param>
        /// <returns>True if the type can be converted, false otherwise.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// This returns whether or not the converter can convert to the specified type.
        /// </summary>
        /// <param name="context">The context under which the conversion is happening.</param>
        /// <param name="destinationType">The destination type to convert to.</param>
        /// <returns>True if the destination type can be converted to, false otherwise.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            // make sure that the destination type implements the IWorkerTask interface or
            // we're dead in the water
            if (destinationType.IsAssignableFrom(destinationType))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// This will convert the specified value into a concrete object that can be instantiated.
        /// </summary>
        /// <param name="context">The context under which to perform the conversion.</param>
        /// <param name="culture">The current culture that the conversion must happen under.</param>
        /// <param name="value">The value to convert into the specified type.</param>
        /// <returns>An instance of the specified type.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // make sure that the destination type implements the IWorkerTask interface or
            // we're dead in the water
            if (value is string)
            {
                string typeName = (value as string ?? string.Empty);
                object instance = InstantiateFromAssemblies(typeName, GetAssembliesFromEntryPath());
                if (instance != null)
                {
                    return instance;
                }
            }


            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// This will convert the specified data type to a string format.
        /// </summary>
        /// <param name="context">The context under which to convert the type.</param>
        /// <param name="culture">The culture under which the conversion is taking place.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="destinationType">The destination data type to convert to.</param>
        /// <returns>The converted form of the object instance.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture,
                                         object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.GetType().Name;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This will attempt to recursively instantiate the object from the set of assemblies provided.
        /// </summary>
        /// <param name="typeName">The type name to look for.</param>
        /// <param name="assemblies">The assemblies to search through.</param>
        /// <returns>An instance of the object if found, false otherwise.</returns>
        /// <exception cref="TypeInitializationException">Thrown if the named type cannot be loaded or 
        /// instantiated.</exception>
        private object InstantiateFromAssemblies(string typeName, IEnumerable<Assembly> assemblies)
        {
            // go through all loaded assemblies looking for a type that matches the name. We'll
            // exclude Microsoft/System namespaces as they contain most of the .NET framework
            // whereas we're looking for custom objects.
            HashSet<string> assemblyExcludeList = new HashSet<string>(new string[]
                {
                    "mscorlib",             // core framework
                    "vshost"                // debugger
                });

            object instance = null;
            foreach (Assembly a in assemblies)
            {
                // ignore core .NET assemblies and our logging tool
                string assemblyName = a.GetName().Name;
                if (assemblyExcludeList.Contains(assemblyName)
                    || assemblyName.IndexOf("Microsoft.", StringComparison.InvariantCultureIgnoreCase) == 0
                    || assemblyName.IndexOf("System.", StringComparison.InvariantCultureIgnoreCase) == 0
                    || assemblyName.IndexOf("NLog.", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    continue;
                }

                // load the types and see if we find a match
                foreach (Type t in a.GetTypes())
                {
                    // does this type match that of the specified value
                    if (t.Name != typeName)
                    {
                        continue;
                    }

                    // create an instance
                    instance = Activator.CreateInstance(t);
                    if (instance == null)
                    {
                        throw new TypeInitializationException(t.FullName, new Exception(string.Format("Unable to initialize type [{0}]", typeName)));
                    }

                    // confirm that this implements the appropriate interface
                    if (!(instance is IWorkerTask))
                    {
                        throw new TypeInitializationException(t.FullName, new Exception(string.Format("Type [{0}] doesn't implement interface IWorkerTask", typeName)));
                    }

                    // if we get here we're good
                    return instance;
                }
            }

            // the type doesn't exist anywhere in the found assemblies
            return null;
        }

        /// <summary>
        /// This will return a list of all .NET assemblies from the entry assembly's folder.
        /// </summary>
        /// <returns>The list of .NET assemblies from the entry executable's folder.</returns>
        private List<Assembly> GetAssembliesFromEntryPath()
        {
            List<Assembly> assemblies = new List<Assembly>();

            string executingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            _logger.Trace("Attempting to load assemblies present in [{0}]", executingPath);
            foreach (string filePath in Directory.GetFiles(executingPath, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(filePath);
                    _logger.Trace("Assembly [{0}] loaded successfully.", assembly);
                    assemblies.Add(assembly);
                }
                catch (Exception ex)
                {
                    // log but otherwise ignore any errors
                    _logger.Warn(ex, "There was a problem loading assembly [{0}]", filePath);
                }
            }

            return assemblies;
        }
        #endregion
    }
}