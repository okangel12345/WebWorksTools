﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorksCore
{
    public class Utilities
    {
        public static void EnsureFileExists(string filePath, string? type = null)
        {
            type = type ?? "file";

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"The {type} was not found at:\n{filePath}",
                                "File not found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }
        }
    }
}