using Ninject;
using Ninject.Modules;

namespace alwfx.UI.Infrastructure
{
    /// <summary>
    /// Composition root for dependency injection
    /// </summary>
    public class CompositionRoot
    {
        /// <summary>
        /// Overrides standard kernel with ninject kernel.
        /// </summary>
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
