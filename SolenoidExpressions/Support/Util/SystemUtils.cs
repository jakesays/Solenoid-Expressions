
/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;


namespace Solenoid.Expressions.Support.Util
{
    /// <summary>
    /// Utility class containing miscellaneous system-level functionality.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    public static class SystemUtils
    {
        private static bool _assemblyResolverRegistered = false;
        private static readonly object _assemblyResolverLock;

        private static readonly bool _isMono;
        private static readonly bool _isClr4;

        static SystemUtils()
        {
            _isMono = Type.GetType("Mono.Runtime") != null;
            _isClr4 = Environment.Version.Major == 4;
            _assemblyResolverLock = new object();
        }

        /// <summary>
        /// Registers assembly resolver that iterates over the
        /// assemblies loaded into the current <see cref="AppDomain"/>
        /// in order to find an assembly that cannot be resolved.
        /// </summary>
        /// <remarks>
        /// This method has to be called if you need to serialize dynamically
        /// generated types in transient assemblies, such as Spring AOP proxies,
        /// because standard .NET serialization engine always tries to load
        /// assembly from the disk.
        /// </remarks>
        public static void RegisterLoadedAssemblyResolver()
        {
            if (!_assemblyResolverRegistered)
            {
                lock (_assemblyResolverLock)
                {
                    AppDomain.CurrentDomain.AssemblyResolve += LoadedAssemblyResolver;
                    _assemblyResolverRegistered = true;
                }
            }
        }

        private static Assembly LoadedAssemblyResolver(object sender, ResolveEventArgs args)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
	        return loadedAssemblies.FirstOrDefault(assembly => assembly.FullName == args.Name);
        }


        /// <summary>
        /// Returns true if running on Mono
        /// </summary>
        /// <remarks>Tests for the presence of the type Mono.Runtime</remarks>
        public static bool MonoRuntime
        {
            get { return _isMono; }
        }

        /// <summary>
        /// Returns true if running on CLR 4.0 under InProc SxS mode
        /// </summary>
        public static bool Clr4Runtime
        {
            get { return _isClr4; }
        }

        /// <summary>
        /// Gets the thread id for the current thread. Use thread name is available,
        /// otherwise use CurrentThread.GetHashCode() for .NET 1.0/1.1 and 
        /// CurrentThread.ManagedThreadId otherwise.
        /// </summary>
        /// <value>The thread id.</value>
        public static string ThreadId
        {
            get
            {
                var name = Thread.CurrentThread.Name;
                if (StringUtils.HasText(name))
                {
                    return name;
                }
	            return Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}