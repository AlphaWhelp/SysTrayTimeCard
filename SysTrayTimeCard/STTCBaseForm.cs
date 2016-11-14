using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace SysTrayTimeCard
{
    // This attribute is not strictly necessary, but enables the abstract form to work in Designer
    [TypeDescriptionProvider(typeof(STTCBaseFormDescriptionProvider<STTCBaseForm, Form>))]
    public abstract class STTCBaseForm : Form
    {
        /// <summary>
        /// Overload for null argument
        /// </summary>
        public void displayMsg() { displayMsg(null); }

        /// <summary>
        /// Custom display message function
        /// </summary>
        /// <param name="arg">Argument to be handled conditionally by overload.</param>
        public virtual void displayMsg(string arg) { }
    }

    /// <summary>
    /// Description Provider for the abstract class to allow it to work in Designer.
    /// Strongly typed to prevent conflicts.
    /// </summary>
    /// <typeparam name="STTCBaseForm">SysTrayTmeCard.STTCBaseForm</typeparam>
    /// <typeparam name="Form">System.Windows.Forms.Form</typeparam>
    public class STTCBaseFormDescriptionProvider<STTCBaseForm, Form> : TypeDescriptionProvider
    {
        public STTCBaseFormDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(STTCBaseForm))) { }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(STTCBaseForm)) return typeof(Form);
            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(STTCBaseForm)) objectType = typeof(Form);
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
