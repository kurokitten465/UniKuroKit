using KuroKitten.UniKuroKit.Core;

namespace KuroKitten.UniKuroKit.Samples
{
    // This class demonstrates the MonoSingleton pattern - a singleton implemented as a MonoBehaviour
    // Inherits from MonoSingleton<T> generic base class, making this class both the singleton and the initialization handler
    public class ConcreteMonoSingleton : MonoSingleton<ConcreteMonoSingleton>
    {
        // Override the Awake lifecycle method - called when the GameObject is first initialized
        // This is where singleton setup occurs
        protected override void Awake()
        {
            // Call the base class Awake method to perform standard singleton initialization
            base.Awake();

            // Set the singleton instance to persist across scene loads
            // This prevents the GameObject from being destroyed when loading new scenes
            IsPersistent = false;
        }

        // Override the OnDestroy lifecycle method - called when the GameObject is destroyed
        // This allows cleanup of singleton resources before destruction
        protected override void OnDestroy()
        {
            // Call the base class OnDestroy method to perform standard singleton cleanup
            base.OnDestroy();
        }

        // Auto-property that stores an integer value, initialized to 100
        // The private setter ensures the value can only be modified through Increase/Decrease methods
        public int Number { get; private set; } = 100;

        public void Increase(int num) => Number += num;

        public void Decrease(int num) => Number -= num;
    }
}
