using SpideyTextureScaler;
using WebWorks;
using WebWorks.Utilities;
using WebWorks.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebWorks.Windows;
using WebWorks.Windows.Search;
using WebWorks.Windows.Tools;

namespace WebWorks.Utilities
{
    //----------------------------------------------------------------------------------------------
    //
    // Different environments of InsomniacToolbox
    //
    //----------------------------------------------------------------------------------------------
    internal class SetEnvironment {

        // Initialize forms
        //------------------------------------------------------------------------------------------
        public static Spandex.Form1? spandexForm;
        public static SpideyTexture? silkTextureForm;
        public static ModelToolsGUI.ModelToolGUI? modelToolGUI;
        public static ConfigWeaver.ConfigWeaverForm? configWeaver;
        public static SpideyAtmos.SpideyAtmosForm? spideyAtmos;
        static MainWindow mainWindow = MainWindow.Instance;

        // Environments
        //------------------------------------------------------------------------------------------
        public static void Spandex()
        {
            LoadForm(ref spandexForm, () =>
            {
                string[] args = { "" };
                spandexForm = new Spandex.Form1(args, mainWindow._selectedHashes);
            }, "WebWorks - Spandex");
        }
        public static void SilkTexture()
        {
            LoadForm(ref silkTextureForm, () =>
            {
                var program = new SpideyTextureScaler.Program
                {
                    texturestats = new List<TextureBase>
            {
                new Source(),
                new DDS(),
                new Output()
            }
                };

                silkTextureForm = new SpideyTexture(program);
            }, "WebWorks - Silk Texture");
        }
        public static void ModdingTool()
        {
            mainWindow.panel_Main.Visible = false;
            mainWindow.splitContainer1.Visible = true;
            mainWindow.Text = "WebWorks - Modding Tool";
        }
        public static void ModelToolGUI()
        {
            LoadForm(ref modelToolGUI, () =>
            {
                modelToolGUI = new ModelToolsGUI.ModelToolGUI();
            }, "WebWorks - Model Tools GUI");
        }
        public static void ConfigWeaver()
        {
            LoadForm(ref configWeaver, () =>
            {
                configWeaver = new ConfigWeaver.ConfigWeaverForm();
            }, "WebWorks - Config Weaver");
        }

        public static void SpideyAtmos()
        {
            LoadForm(ref spideyAtmos, () =>
            {
                spideyAtmos = new SpideyAtmos.SpideyAtmosForm();
            }, "WebWorks - Spidey Atmos");
        }

        public static void Search()
        {
            List<WebWorks.Utilities.Asset> _assets = mainWindow._assets;
            Dictionary<string, List<int>> _assetsByPath = mainWindow._assetsByPath;

            SearchWindow searchWindow = new SearchWindow(_assets, _assetsByPath);
            searchWindow.Show();
        }
        public static void JumpTo()
        {
            var window = new JumpToWindow();
            window.ShowDialog();

            if (!window.Jumped) return;
            mainWindow.JumpTo(window.Path.Trim());
        }
        public static void HashTool()
        {
            HashTool hashTool = new HashTool();
            hashTool.Show();
        }
        public static void Information()
        {
            InformationWindow information = new InformationWindow();
            information.ShowDialog();
        }
        public static void Settings()
        {
            SettingsWindow settings = new SettingsWindow();
            settings.ShowDialog();
        }
        public static void Home()
        {
            mainWindow.splitContainer1.Visible = false;

            ToolUtils toolUtils = new ToolUtils();
            SpideyHome spideyHome = new SpideyHome();

            LoadFormIntoPanel(spideyHome, mainWindow.panel_Main);
        }

        //------------------------------------------------------------------------------------------
        // Helper methods
        //------------------------------------------------------------------------------------------
        public static void LoadFormIntoPanel(Form form, Panel panel)
        {
            panel.Visible = false;

            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            panel.Controls.Clear();
            panel.Controls.Add(form);

            form.Show();

            panel.Visible = true;
        }
        private static void LoadForm<T>(ref T form, Action formInitializer, string windowTitle) where T : Form
        {
            if (form == null || form.IsDisposed)
            {
                formInitializer();
            }

            LoadFormIntoPanel(form, mainWindow.panel_Main);
            mainWindow.Text = windowTitle;
        }
    }
}
