using UnityEngine;
using UnityEngine.UI;

namespace KuroKitten.UniKuroKit.Samples
{
    // This class is a client that interacts with the ConcreteMonoSingleton
    // It demonstrates how to access and manipulate the singleton instance from a UI-driven MonoBehaviour
    public class SingletonClient : MonoBehaviour
    {
        // SerializeField exposes this field in the Inspector for easy assignment of the UI Text component
        [SerializeField] Text _text;
        // Serialized field that determines how much to increase/decrease the singleton value per button click
        [SerializeField] int _amount = 10;

        // Private field to cache the singleton instance for easy access throughout this class
        ConcreteMonoSingleton singleton;

        // Unity lifecycle method called when the GameObject is initialized
        // Used here to get the singleton instance and display the initial value
        void Awake()
        {
            // Access the singleton instance directly through the Instance property
            // This works because ConcreteMonoSingleton is a MonoSingleton<T>
            singleton = ConcreteMonoSingleton.Instance;

            // Update the UI Text to display the current value from the singleton
            // Uses string interpolation with typeof()
            _text.text = $"Number from {typeof(ConcreteMonoSingleton)} is {singleton.Number}";
        }

        // Public method called when the increase button is clicked (UI event)
        // Increases the singleton's Number property and updates the display
        public void Increase()
        {
            // Call the Increase method on the singleton with the configured amount
            singleton.Increase(_amount);
            // Update the UI Text to reflect the new value from the singleton
            _text.text = $"Number from {typeof(ConcreteMonoSingleton)} is {singleton.Number}";
        }
        
        // Public method called when the decrease button is clicked (UI event)
        // Decreases the singleton's Number property and updates the display
        public void Decrease()
        {
            // Call the Decrease method on the singleton with the configured amount
            singleton.Decrease(_amount);
            // Update the UI Text to reflect the new value from the singleton
            _text.text = $"Number from {typeof(ConcreteMonoSingleton)} is {singleton.Number}";
        }
    }
}
