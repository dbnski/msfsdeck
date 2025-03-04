﻿namespace Loupedeck.MsfsPlugin
{
    using System;

    using Loupedeck.MsfsPlugin.input;

    class RPMInput : DefaultInput
    {
        public RPMInput() : base("RPM/N1", "Display RPM for or N1", "Misc")
        {
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.ENGINE_TYPE)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.ENGINE_NUMBER)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E1RPM)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E2RPM)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E1N1)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E2N1)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E3N1)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.E4N1)));
        }
        protected override String GetValue()
        {
            String result;
            switch (this._bindings[0].MsfsValue)
            {
                case 0:
                    result = "RPM\n" + (this._bindings[1].MsfsValue == 2
                                    ? this._bindings[2].MsfsValue.ToString() + "\n" + this._bindings[3].MsfsValue.ToString()
                                    : this._bindings[2].MsfsValue.ToString());
                    break;
                case 1:
                case 5:
                    result = "N1\n" + (this._bindings[1].MsfsValue == 4
                    ? this._bindings[4].MsfsValue.ToString() + "\n" + this._bindings[5].MsfsValue.ToString() + "\n" + this._bindings[6].MsfsValue.ToString() + "\n" + this._bindings[7].MsfsValue.ToString()
                    : this._bindings[1].MsfsValue == 2
                                    ? this._bindings[4].MsfsValue.ToString() + "\n" + this._bindings[5].MsfsValue.ToString()
                                    : this._bindings[4].MsfsValue.ToString());
                    break;
                default:
                    result = "N/A";
                    break;
            }
            return result;
        }
    }
}

