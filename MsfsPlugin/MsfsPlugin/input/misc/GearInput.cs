﻿namespace Loupedeck.MsfsPlugin
{
    using System;

    using Loupedeck.MsfsPlugin.input;
    class GearInput : DefaultInput
    {
        public GearInput() : base("Gear", "Display gears state", "Misc")
        {
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.GEAR_RETRACTABLE)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.GEAR_FRONT)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.GEAR_LEFT)));
            this._bindings.Add(MsfsData.Instance.Register(new Binding(BindingKeys.GEAR_RIGHT)));
        }
        protected override BitmapImage GetImage(PluginImageSize imageSize)
        {
            using (var bitmapBuilder = new BitmapBuilder(imageSize))
            {
                if (this._bindings[0].ControllerValue == 1)
                {
                    if (this._bindings[1].ControllerValue == 0 || this._bindings[1].ControllerValue == 10)
                    {
                        bitmapBuilder.DrawText("\t" + this.GetDisplay(this._bindings[1].MsfsValue) + "\n" + this.GetDisplay(this._bindings[2].MsfsValue) + "\t" + this.GetDisplay(this._bindings[3].MsfsValue), BitmapColor.White);
                    }
                    else
                    {
                        bitmapBuilder.DrawText("\t" + this.GetDisplay(this._bindings[1].MsfsValue) + "\n" + this.GetDisplay(this._bindings[2].MsfsValue) + "\t" + this.GetDisplay(this._bindings[3].MsfsValue), new BitmapColor(255, 165, 0));
                    }
                }
                else
                {
                    bitmapBuilder.DrawText("\t" + this.GetDisplay(this._bindings[1].MsfsValue) + "\n" + this.GetDisplay(this._bindings[2].MsfsValue) + "\t" + this.GetDisplay(this._bindings[3].MsfsValue), new BitmapColor(0, 0, 255));
                }
                return bitmapBuilder.ToImage();
            }
        }
        private String GetDisplay(Double gearPos) => gearPos == 0 ? "-" : gearPos == 10 ? "|" : "/";
        protected override void ChangeValue() => this._bindings[1].SetControllerValue(1);
    }
}

