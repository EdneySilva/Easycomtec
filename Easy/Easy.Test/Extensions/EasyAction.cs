using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Easy.Test.Extensions
{
    class EasyAction : Actions
    {
        static FieldInfo ActionField { get; }
        static FieldInfo ActionListField { get; }
        static EasyAction()
        {

            ActionField = typeof(EasyAction).BaseType.GetRuntimeFields().FirstOrDefault(w => w.Name.Equals("action"));
            ActionListField = ActionField.FieldType.GetRuntimeFields().FirstOrDefault();
        }

        public EasyAction(IWebDriver driver) : base(driver)
        {

        }

        new public IAction Build()
        {
            var result = base.Build();
            var actionValue = ActionField.GetValue(this);
            var actionListValue = (List<IAction>)ActionListField.GetValue(actionValue);
            IAction[] actionArray = new IAction[actionListValue.Count];
            actionListValue.CopyTo(actionArray);
            actionListValue.Clear();
            return new InternalAction(actionArray);
        }

        class InternalAction : IAction
        {
            IAction[] Actions { get; }
            public InternalAction(IAction[] actions)
            {
                Actions = actions;
            }

            public void Perform()
            {
                foreach (var item in Actions)
                {
                    item.Perform();
                }
            }
        }
    }
}
