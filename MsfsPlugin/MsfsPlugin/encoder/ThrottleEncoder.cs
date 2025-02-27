﻿namespace Loupedeck.MsfsPlugin
{
    using System;

    using Loupedeck.MsfsPlugin.encoder;
    class ThrottleEncoder : DefaultEncoder
    {
        public ThrottleEncoder() : base("Throttle", "Current throttle", "Nav", true, -100, 100, 1)
        {
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.MIN_THROTTLE)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.THROTTLE)));
        }
        protected override void RunCommand(String actionParameter) => this.SetValue(0);
        protected override Int64 GetValue() => this._bindings[1].ControllerValue;
        protected override void SetValue(Int64 newValue) => this._bindings[1].SetControllerValue(newValue);
    }
}
