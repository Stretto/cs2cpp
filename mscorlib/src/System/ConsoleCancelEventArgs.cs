// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/*=============================================================================
**
**
**
** Purpose: This class provides support goop for hooking Control-C and 
**          Control-Break, then preventing Control-C from interrupting the 
**          process.
**
**
=============================================================================*/
namespace System {
    using System;
    using System.Diagnostics.Contracts;

    public delegate void ConsoleCancelEventHandler(Object sender, ConsoleCancelEventArgs e);


    [Serializable]
    public sealed class ConsoleCancelEventArgs : EventArgs
    {
        private ConsoleSpecialKey _type;
        private bool _cancel;  // Whether to cancel the CancelKeyPress event

        internal ConsoleCancelEventArgs(ConsoleSpecialKey type)
        {
            _type = type;
            _cancel = false;
        }

        // Whether to cancel the break event.  By setting this to true, the
        // Control-C will not kill the process.
        public bool Cancel {
            get { return _cancel; }
            set {
                _cancel = value;
            }
        }

        public ConsoleSpecialKey SpecialKey {
            get { return _type; }
        }
    }
}
