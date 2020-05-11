using System;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace CC.Base.UI.Logger
{
    public class TextBoxAppender : AppenderSkeleton
    {
        private TextBox _textBox;
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_textBox == null)
            {
                if (String.IsNullOrEmpty(FormName) ||
                    String.IsNullOrEmpty(TextBoxName))
                    return;

                Form form = Application.OpenForms[FormName];
                if (form == null)
                    return;

                _textBox = form.Controls.Find(TextBoxName, true)[0] as TextBox;
                if (_textBox == null)
                    return;

                form.FormClosing += (s, e) => _textBox = null;
            }

            _textBox.AppendText(
                $"{loggingEvent.TimeStampUtc.ToShortTimeString()}:" +
                $"{loggingEvent.Level.DisplayName.PadLeft(5)}:" +
                $"{loggingEvent.RenderedMessage}{Environment.NewLine}");
        }
    }
}
