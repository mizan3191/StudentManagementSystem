﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentManagementSystem.Foundation.Services
{
    public class DirectoryAdapter : IDirectoryAdapter
    {
        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.Exists(path);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.CreateDirectory(path);
        }
    }
}
