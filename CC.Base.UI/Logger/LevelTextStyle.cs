using System;
using System.Drawing;
using log4net.Util;

namespace CC.Base.UI.Logger
{
    /// <summary>
    ///     A class to act as a mapping between the level that a logging call is made at and
    ///     the text style in which it should be displayed.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Defines the mapping between a level and the text style in which it should be displayed..
    ///     </para>
    /// </remarks>
    public class LevelTextStyle : LevelMappingEntry
    {
        /// <summary>
        ///     Name of a KnownColor used for text
        /// </summary>
        public string TextColorName { get; set; } = "ControlText";

        /// <summary>
        ///     Name of a KnownColor used as text background
        /// </summary>
        public string BackColorName { get; set; } = "ControlLight";

        /// <summary>
        ///     Name of a font family
        /// </summary>
        public string FontFamilyName { get; set; } = null;

        /// <summary>
        ///     Display level in bold style
        /// </summary>
        public bool Bold { get; set; } = false;

        /// <summary>
        ///     Display level in italic style
        /// </summary>
        public bool Italic { get; set; } = false;

        /// <summary>
        ///     Font size of level, 0 to use default
        /// </summary>
        public float PointSize { get; set; } = 0.0f;

        internal Color TextColor { get; private set; }

        internal Color BackColor { get; private set; }

        internal FontStyle FontStyle { get; private set; } = FontStyle.Regular;

        internal Font Font { get; private set; }

        /// <summary>
        ///     Initialize the options for the object
        /// </summary>
        /// <remarks>Parse the properties</remarks>
        public override void ActivateOptions()
        {
            base.ActivateOptions();
            TextColor = Color.FromName(TextColorName);
            BackColor = Color.FromName(BackColorName);
            if (Bold) FontStyle |= FontStyle.Bold;
            if (Italic) FontStyle |= FontStyle.Italic;

            if (FontFamilyName != null)
            {
                var size = PointSize > 0.0f ? PointSize : 8.25f;
                try
                {
                    Font = new Font(FontFamilyName, size, FontStyle);
                }
                catch (Exception)
                {
                    Font = null;
                }
            }
        }
    }
}