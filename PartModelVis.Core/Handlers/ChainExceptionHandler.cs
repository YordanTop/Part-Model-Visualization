using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers
{
    /// <summary>
    /// ChainExceptionHandler checks every boolean logic if it meets the conditions.
    /// </summary>
    public class ChainExceptionHandler
    {
        private class HandlerNode
        {
            public IExceptionHandler Handler { get; }
            public HandlerNode? NextHandler { get; set; }

            public HandlerNode(IExceptionHandler handler)
            {
                Handler = handler;
            }
        }

        private HandlerNode _chainHandler;

        public ChainExceptionHandler(IExceptionHandler headException, params IExceptionHandler[] followingExeptions)
        {

            var head = new HandlerNode(headException);
            var current = head;

            //Chaining the handlers.
            foreach (var currentHandler in followingExeptions)
            {
                var newNode = new HandlerNode(currentHandler);
                current.NextHandler = newNode;
                current = newNode;
            }

            _chainHandler = head;

        }
        /// <summary>
        /// Checker if all of the conditions are true.
        /// </summary>
        public bool CheckConditions()
        {
            while(_chainHandler != null)
            {
                //Checks if the condition is false
                if (!_chainHandler.Handler.IsConditionValued())
                {
                    MessageBox.Show(_chainHandler.Handler.MessageHandler);
                    return false;
                }

                //if not the handler goes to the next condition
                _chainHandler = _chainHandler.NextHandler;
            }
            return true;
        }

    }
}
