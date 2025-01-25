using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WebWorksShared
{
    public class ToolboxStyle
    {
        // Public static method to apply all styles to a form
        //------------------------------------------------------------------------------------------
        static Color accent = Color.FromArgb(119, 204, 221);
        static Color accentGrid = Color.FromArgb(17, 130, 135);

        // Splitter colors
        static Color splitter_Color = Color.FromArgb(64, 64, 64);
        static Color splitter_panelBackgroundColor = Color.FromArgb(12,12,12);

        // Data grid
        static Color datagrid_backgroundColor = Color.FromArgb(12, 12, 12);
        static Color datagrid_gridLineColor = splitter_Color;
        static Color datagrid_headerBackColor = Color.FromArgb(30, 30, 30);
        static Color datagrid_headerForeColor = Color.Gainsboro;
        static Color datagrid_rowBackColor = Color.FromArgb(20, 20, 20);
        static Color datagrid_rowForeColor = Color.Gainsboro;
        static Color datagrid_selectedRowForeColor = Color.LightGray;
        static Color datagrid_alternatingRowBackColor = Color.FromArgb(25, 25, 25);

        // Group box
        static Color groupbox_borderColor = Color.FromArgb(72, 72, 72);
        static Color groupbox_backgroundColor = datagrid_headerBackColor;
        static Color groupbox_textColor = Color.WhiteSmoke;

        // Buttons
        static Color button_borderColor = groupbox_borderColor;
        static Color button_topColor = Color.FromArgb(54, 54, 54);
        static Color button_bottomColor = Color.FromArgb(44, 44, 44);
        static Color button_foreColor = Color.WhiteSmoke;

        // Title bar
        static Color titlebar_color = datagrid_alternatingRowBackColor;
        static Color titlebar_fill_color = Color.FromArgb(18, 18, 18);
        static Color titlebar_border_startColor = Color.FromArgb(0x38, 0x38, 0x38);
        static Color titlebar_border_endColor = Color.FromArgb(24, 24, 24);
        static Color titlebar_forecolor = Color.Black;
        static Color titlebar_forecolorSelected = Color.White;

        // Main menu strip
        static Color mainmenustrip_backcolor = datagrid_alternatingRowBackColor;
        static Color mainmenustrip_forecolor = Color.White;

        // Tree view
        static Color tree_backgroundColor = datagrid_backgroundColor;
        static Color tree_rowForeColor = Color.Gainsboro;

        //------------------------------------------------------------------------------------------
        public static void ApplyToolBoxStyle(Control parent, IntPtr hwnd, MenuStrip strip = null, ContextMenuStrip context = null, string accentColor = null, string accentColorGrid = null)
        {
            if (!string.IsNullOrEmpty(accentColor))
            {
                accentColor = accentColor.TrimStart('#');
                if (accentColor.Length == 6)
                {
                    accent = Color.FromArgb(
                        Convert.ToInt32(accentColor.Substring(0, 2), 16),
                        Convert.ToInt32(accentColor.Substring(2, 2), 16),
                        Convert.ToInt32(accentColor.Substring(4, 2), 16)
                    );
                }
            }

            if (!string.IsNullOrEmpty(accentColorGrid))
            {
                accentColorGrid = accentColorGrid.TrimStart('#');
                if (accentColorGrid.Length == 6)
                {
                    accentGrid = Color.FromArgb(
                        Convert.ToInt32(accentColorGrid.Substring(0, 2), 16),
                        Convert.ToInt32(accentColorGrid.Substring(2, 2), 16),
                        Convert.ToInt32(accentColorGrid.Substring(4, 2), 16)
                    );
                }
            }

            ApplySplitContainerStyle(parent);
            ApplyDataGridViewStyle(parent);
            ApplyGroupBoxStyle(parent);
            ApplyButtonStyle(parent);
            SetTitleBarColor(hwnd);
            ApplyMenuStripDark(strip);
            ApplyContextMenuStripDark(context);
            ApplyTreeViewStyle(parent);
        }

        //------------------------------------------------------------------------------------------

        #region CustomToolStripRenderer
        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // Draw a black border explicitly
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        new Rectangle(Point.Empty, e.ToolStrip.Size),
                        titlebar_border_startColor,
                        titlebar_border_endColor,
                        -90f)) 
                {
                    using (Pen gradientPen = new Pen(gradientBrush))
                    {
                        e.Graphics.DrawRectangle(gradientPen, new Rectangle(Point.Empty, e.ToolStrip.Size - new Size(1, 1)));
                    }
                }
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                // Ensure the background is fully black
                using (SolidBrush blackBrush = new SolidBrush(titlebar_fill_color))
                {
                    e.Graphics.FillRectangle(blackBrush, e.AffectedBounds);
                }
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                // Set menu item background explicitly
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                using (SolidBrush blackBrush = new SolidBrush(titlebar_fill_color))
                {
                    e.Graphics.FillRectangle(blackBrush, rect);
                }

                // Highlight selected or hovered items with a gray shade
                if (e.Item.Selected)
                {
                    using (SolidBrush grayBrush = new SolidBrush(accent))
                    {
                        e.Graphics.FillRectangle(grayBrush, rect);
                    }

                    e.Item.ForeColor = titlebar_forecolor;
                }
                else
                {
                    e.Item.ForeColor = titlebar_forecolorSelected;
                }
            }
        }
        #endregion

        #region Controls

        public static void ApplySplitContainerStyle(Control parent)
        {
            int splitter_Width = 6;

            // Recursively apply styles to all SplitContainer controls in the parent container
            void ApplyStyleRecursive(Control parentControl)
            {
                foreach (Control control in parentControl.Controls)
                {
                    if (control is SplitContainer splitContainer)
                    {
                        // Style the SplitContainer itself
                        splitContainer.BackColor = splitter_Color;
                        splitContainer.SplitterWidth = splitter_Width;

                        // Style the panels
                        splitContainer.Panel1.BackColor = splitter_panelBackgroundColor;
                        splitContainer.Panel2.BackColor = splitter_panelBackgroundColor;

                        // Add custom painting for the splitter
                        splitContainer.Paint += (sender, e) =>
                        {
                            // Define the bounds for the splitter
                            Rectangle splitterBounds = splitContainer.Orientation == Orientation.Horizontal
                                ? new Rectangle(0, splitContainer.SplitterDistance, splitContainer.Width, splitter_Width)
                                : new Rectangle(splitContainer.SplitterDistance, 0, splitter_Width, splitContainer.Height);

                            // Fill the splitter with the specified color
                            using (var brush = new SolidBrush(splitter_Color))
                            {
                                e.Graphics.FillRectangle(brush, splitterBounds);
                            }
                        };

                        // Trigger repaint when size or contents change
                        splitContainer.SplitterMoved += (sender, e) => splitContainer.Invalidate();
                    }

                    // Apply recursively to child controls
                    if (control.HasChildren)
                    {
                        ApplyStyleRecursive(control);
                    }
                }
            }

            // Start applying styles from the parent control
            ApplyStyleRecursive(parent);
        }

        public static void ApplyDataGridViewStyle(Control parent)
        {
            void ApplyStyleRecursive(Control parentControl)
            {
                foreach (Control control in parentControl.Controls)
                {
                    if (control is DataGridView dataGridView)
                    {
                        dataGridView.BackgroundColor = datagrid_backgroundColor;
                        dataGridView.GridColor = datagrid_gridLineColor;
                        dataGridView.BorderStyle = BorderStyle.None;

                        dataGridView.EnableHeadersVisualStyles = false;
                        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = datagrid_headerBackColor;
                        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = datagrid_headerForeColor;
                        dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
                        dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                        dataGridView.RowsDefaultCellStyle.BackColor = datagrid_rowBackColor;
                        dataGridView.RowsDefaultCellStyle.ForeColor = datagrid_rowForeColor;
                        dataGridView.RowsDefaultCellStyle.SelectionBackColor = accentGrid; // Use custom selected row background
                        dataGridView.RowsDefaultCellStyle.SelectionForeColor = datagrid_selectedRowForeColor; // Use custom selected row foreground

                        dataGridView.AlternatingRowsDefaultCellStyle.BackColor = datagrid_alternatingRowBackColor;

                        dataGridView.RowTemplate.DefaultCellStyle.BackColor = datagrid_rowBackColor;

                        dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                        dataGridView.RowHeadersDefaultCellStyle.BackColor = datagrid_headerBackColor;
                        dataGridView.RowHeadersDefaultCellStyle.ForeColor = datagrid_headerForeColor;
                        dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView.MultiSelect = true;
                    }

                    if (control.HasChildren)
                    {
                        ApplyStyleRecursive(control);
                    }
                }
            }

            ApplyStyleRecursive(parent);
        }

        public static void ApplyTreeViewStyle(Control parent)
        {
            void ApplyStyleRecursive(Control parentControl)
            {
                foreach (Control control in parentControl.Controls)
                {
                    if (control is TreeView treeView)
                    {
                        treeView.BackColor = tree_backgroundColor;
                        treeView.ForeColor = tree_rowForeColor;

                        treeView.ItemHeight = 20;
                        treeView.Indent = 20;

                        treeView.ForeColor = tree_rowForeColor;
                        treeView.BackColor = tree_backgroundColor;

                        treeView.BorderStyle = BorderStyle.None;
                    }

                    if (control.HasChildren)
                    {
                        ApplyStyleRecursive(control);
                    }
                }
            }

            ApplyStyleRecursive(parent);
        }

        public static void ApplyGroupBoxStyle(Control parent)
        {
            // Configuration for GroupBox styling
            Font textFont = new Font("Segoe UI", 9, FontStyle.Regular);

            // Recursively apply styles to all GroupBoxes in the parent container
            void ApplyStyleRecursive(Control parentControl)
            {
                foreach (Control control in parentControl.Controls)
                {
                    if (control is GroupBox groupBox)
                    {
                        // General appearance
                        groupBox.BackColor = groupbox_backgroundColor;
                        groupBox.ForeColor = groupbox_textColor;
                        groupBox.Font = textFont;

                        // Attach custom paint event for drawing borders and header
                        groupBox.Paint += (sender, e) => DrawCustomGroupBox(groupBox, e, groupbox_borderColor);
                    }

                    // Apply recursively to child controls
                    if (control.HasChildren)
                    {
                        ApplyStyleRecursive(control);
                    }
                }
            }

            // Start applying styles from the parent control
            ApplyStyleRecursive(parent);
        }

        private static void DrawCustomGroupBox(GroupBox groupBox, PaintEventArgs e, Color borderColor)
        {
            // Measure the text header
            SizeF textSize = e.Graphics.MeasureString(groupBox.Text, groupBox.Font);
            Rectangle bounds = groupBox.ClientRectangle;

            // Adjust bounds for the text header
            Rectangle textRect = new Rectangle(bounds.X + 6, bounds.Y, (int)textSize.Width + 10, (int)textSize.Height);
            Rectangle borderRect = new Rectangle(bounds.X, bounds.Y + (int)(textSize.Height / 2), bounds.Width - 1, bounds.Height - (int)(textSize.Height / 2) - 1);

            // Draw background
            using (SolidBrush backgroundBrush = new SolidBrush(groupBox.BackColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, bounds);
            }

            // Create rounded rectangle for the border
            using (GraphicsPath borderPath = CreateRoundedRectanglePath(borderRect, 10)) // 10 is the corner radius
            {
                // Draw border
                using (Pen borderPen = new Pen(borderColor))
                {
                    e.Graphics.DrawPath(borderPen, borderPath);
                }
            }

            // Draw text
            TextRenderer.DrawText(e.Graphics, groupBox.Text, groupBox.Font, textRect, groupBox.ForeColor, TextFormatFlags.Left);
        }

        // Button style will be the same for all forms
        // It's based on QT's button design.
        public static void ApplyButtonStyle(Control parent)
        {
            // Configuration
            bool roundedButtons = true;
            FlatStyle flatStyle = FlatStyle.Flat;
            int borderSize = 2;

            //Color topColor = Color.FromArgb(64,64,64);
            //Color bottomColor = Color.FromArgb(54,54,54);

            // Recursively apply styles to all buttons
            void ApplyStyleRecursive(Control parentControl)
            {
                foreach (Control control in parentControl.Controls)
                {
                    if (control is Button button)
                    {
                        // Set basic button styles
                        button.FlatStyle = flatStyle;
                        button.FlatAppearance.BorderSize = borderSize;
                        button.FlatAppearance.BorderColor = button_borderColor;
                        button.ForeColor = button_foreColor;

                        // Attach custom paint handlers based on configuration
                        button.Paint += roundedButtons
                            ? ((sender, e) => ApplyGradientRounded(button, e, button_topColor, button_bottomColor))
                            : (sender, e) => ApplyGradient(button, e, button_topColor, button_bottomColor);

                        // Invalidate button to handle hover effects
                        button.MouseEnter += (sender, e) => button.Invalidate();
                        button.MouseLeave += (sender, e) => button.Invalidate();
                    }

                    // Apply recursively to child controls
                    if (control.HasChildren)
                    {
                        ApplyStyleRecursive(control);
                    }
                }
            }

            // Start applying styles from the parent control
            ApplyStyleRecursive(parent);
        }

        private static void ApplyGradient(Button button, PaintEventArgs e, Color topColor, Color bottomColor)
        {
            // Hover effect colors
            bool isHovered = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
            Color currentTopColor = isHovered ? ControlPaint.Light(topColor, 0.2f) : topColor;
            Color currentBottomColor = isHovered ? ControlPaint.Light(bottomColor, 0.2f) : bottomColor;

            // Fill background with gradient
            using (var brush = new LinearGradientBrush(button.ClientRectangle, currentTopColor, currentBottomColor, 90f))
            {
                e.Graphics.FillRectangle(brush, button.ClientRectangle);
            }

            // Draw button text
            TextRenderer.DrawText(e.Graphics, button.Text, button.Font, button.ClientRectangle, button.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Draw border
            ControlPaint.DrawBorder(e.Graphics, button.ClientRectangle, button.FlatAppearance.BorderColor, ButtonBorderStyle.Solid);
        }

        private static void ApplyGradientRounded(Button button, PaintEventArgs e, Color topColor, Color bottomColor)
        {
            // Rounded corners radius
            int cornerRadius = 4; // Adjust to change roundness

            // Hover effect colors
            bool isHovered = button.ClientRectangle.Contains(button.PointToClient(Cursor.Position));
            Color currentTopColor = isHovered ? ControlPaint.Light(topColor, 0.2f) : topColor;
            Color currentBottomColor = isHovered ? ControlPaint.Light(bottomColor, 0.2f) : bottomColor;

            // Adjust bounds slightly inward to avoid clipping the border
            Rectangle adjustedBounds = new Rectangle(0, 0, button.Width - 1, button.Height - 1);

            // Create a rounded rectangle path
            using (var path = CreateRoundedRectanglePath(adjustedBounds, cornerRadius))
            {
                // Clear the button background for transparency
                e.Graphics.Clear(button.Parent.BackColor);

                // Clip the drawing area to the rounded path
                e.Graphics.SetClip(path);

                // Fill the button background with a gradient
                using (var brush = new LinearGradientBrush(adjustedBounds, currentTopColor, currentBottomColor, 90f))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Reset clipping to default for drawing text and border
                e.Graphics.ResetClip();

                // Draw the button's text
                TextRenderer.DrawText(
                    e.Graphics,
                    button.Text,
                    button.Font,
                    adjustedBounds,
                    button.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                // Draw the rounded border
                using (var borderPen = new Pen(button.FlatAppearance.BorderColor, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Ensures smooth rounded edges
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            // Top-left corner
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);

            // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);

            // Bottom-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);

            // Bottom-left corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure(); // Closes the path to form the rounded rectangle
            return path;
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_CAPTION_COLOR = 35;

        // Static method to set title bar color
        public static void SetTitleBarColor(IntPtr hwnd)
        {
            // Swap the Red and Blue components of the color
            Color swappedColor = Color.FromArgb(titlebar_color.A, titlebar_color.B, titlebar_color.G, titlebar_color.R);

            // Multiply each RGB component by 0.7 to darken the color
            int red = (int)(swappedColor.R * 0.7);
            int green = (int)(swappedColor.G * 0.7);
            int blue = (int)(swappedColor.B * 0.7);

            // Ensure that the values are within the valid range [0, 255]
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            // Create a new color with the modified values
            Color finalColor = Color.FromArgb(swappedColor.A, red, green, blue);

            // Convert the modified color to ARGB format and set the window title bar color
            int finalColorValue = finalColor.ToArgb() & 0x00FFFFFF;

            // Call DwmSetWindowAttribute to change the title bar color
            DwmSetWindowAttribute(hwnd, DWMWA_CAPTION_COLOR, ref finalColorValue, sizeof(int));
        }

        public static void ApplyContextMenuStripDark(ContextMenuStrip contextMenuStrip, Color? accentColor = null)
        {
            if (contextMenuStrip != null)
            {
                contextMenuStrip.BackColor = mainmenustrip_backcolor;
                contextMenuStrip.ForeColor = mainmenustrip_forecolor;

                contextMenuStrip.Renderer = new CustomToolStripRenderer();

                // Loop through all items in the ContextMenuStrip
                foreach (var item in contextMenuStrip.Items)
                {
                    // Check if the item is a ToolStripMenuItem
                    if (item is ToolStripMenuItem menuItem)
                    {
                        ApplyMenuItemStyle(menuItem); // Apply style only if it's a ToolStripMenuItem
                    }
                }
            }
        }

        public static void ApplyMenuStripDark(MenuStrip MainMenuStrip, Color? accentColor = null)
        {
            if (MainMenuStrip != null)
            {
                MainMenuStrip.BackColor = mainmenustrip_backcolor;
                MainMenuStrip.ForeColor = mainmenustrip_forecolor;

                // Set custom renderer to ensure black border and full control styling
                MainMenuStrip.Renderer = new CustomToolStripRenderer();

                foreach (ToolStripMenuItem menuItem in MainMenuStrip.Items)
                {
                    ApplyMenuItemStyle(menuItem);
                }
            }
        }

        private static void ApplyMenuItemStyle(ToolStripMenuItem menuItem)
        {
            menuItem.BackColor = titlebar_forecolor; // Menu items background set to black
            menuItem.ForeColor = titlebar_forecolorSelected;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                subItem.BackColor = titlebar_border_endColor; // Submenu items background set to black
                subItem.ForeColor = titlebar_forecolorSelected;
            }
        }

        #endregion Controls    
    }
}