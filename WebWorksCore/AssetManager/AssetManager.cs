using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorksCore
{
    //----------------------------------------------------------------------------------------------
    //
    // Shared Asset Manager - (WebWorks, Silk Texture, Spandex, Weather Tuner)
    //
    //----------------------------------------------------------------------------------------------
    public class AssetManager
    {
        public enum AssetType
        {
            Unknown,
            Atmosphere,
            Texture,
            Material
        }

        public enum AssetGame
        {
            MSM1,
            MSMM,
            RCRA,
            MSM2
        }

        // Define asset parameters
        //------------------------------------------------------------------------------------------
        public byte[] _assetBytes;
        public AssetType _assetType { get; }
        public AssetGame _assetGame { get; }
        public byte[] _assetHeader { get; }
        public int _DAT1Offset { get; }

        //------------------------------------------------------------------------------------------
        public AssetManager(byte[] fileBytes)
        {
            if (fileBytes == null)
                throw new ArgumentNullException(nameof(fileBytes));

            _assetBytes = fileBytes;

            // Define asset parameters
            _DAT1Offset = Find1TADMarker();
            (_assetType, _assetGame) = GetAssetType();
            _assetHeader = GetAssetHeader();
        }

        // Private method to find the "1TAD" offset in the asset
        //------------------------------------------------------------------------------------------
        private int Find1TADMarker()
        {
            byte[] marker = { 0x31, 0x54, 0x41, 0x44 };

            for (int i = 0; i <= _assetBytes.Length - marker.Length; i++)
            {
                if (_assetBytes.Skip(i).Take(marker.Length).SequenceEqual(marker))
                    return i;
            }
            return -1;
        }

        // Generally we can use MAGIC to identify the asset type as well as the game, it may be worth
        // looking to use the built string instead
        //------------------------------------------------------------------------------------------
        private (AssetType, AssetGame) GetAssetType()
        {
            if (_DAT1Offset == -1)
            {
                return (AssetType.Unknown, AssetGame.MSM1); // If the marker is not found
            }

            byte[] magicBytes = _assetBytes.Skip(_DAT1Offset + 4).Take(4).ToArray();
            Array.Reverse(magicBytes);

            uint foundMagic = BitConverter.ToUInt32(magicBytes, 0);

            // Define MAGIC and their respective values

            switch (foundMagic)
            {
                case 0x4FBCF482:
                    return (AssetType.Atmosphere, AssetGame.MSM2);
                default:
                    return (AssetType.Unknown, AssetGame.MSM1); // Default game to MSM1
            }
        }

        // Get the bytes of any asset section
        //------------------------------------------------------------------------------------------
        public byte[] GetAssetSection(Enum sectionType)
        {
            return GetAssetSection(Convert.ToUInt32(sectionType));
        }

        private byte[] GetAssetSection(uint section)
        {
            if (_DAT1Offset == -1) return null;

            int offset = _DAT1Offset + 16; // Skip "1TAD", MAGIC, Asset Size, and Number of Sections
            int numSections = BitConverter.ToInt32(_assetBytes, _DAT1Offset + 12);

            for (int i = 0; i < numSections; i++)
            {
                int sectionIndex = offset + (i * 12);
                uint sectionID = BitConverter.ToUInt32(_assetBytes, sectionIndex);

                if (sectionID == section)
                {
                    int sectionOffset = BitConverter.ToInt32(_assetBytes, sectionIndex + 4) + _DAT1Offset;
                    int sectionSize = BitConverter.ToInt32(_assetBytes, sectionIndex + 8);

                    return _assetBytes.Skip(sectionOffset).Take(sectionSize).ToArray();
                }
            }
            return null;
        }

        // Get the offset of any asset section
        //------------------------------------------------------------------------------------------
        public int GetAssetSectionOffset(Enum sectionType)
        {
            return GetAssetSectionOffset(Convert.ToUInt32(sectionType));
        }
        private int GetAssetSectionOffset(uint section)
        {
            if (_DAT1Offset == -1) return -1;

            int offset = _DAT1Offset + 16; // Skip "1TAD", MAGIC, Asset Size, and Number of Sections
            int numSections = BitConverter.ToInt32(_assetBytes, _DAT1Offset + 12);

            for (int i = 0; i < numSections; i++)
            {
                int sectionIndex = offset + (i * 12);
                uint foundSectionID = BitConverter.ToUInt32(_assetBytes, sectionIndex);

                if (foundSectionID == section)
                {
                    return BitConverter.ToInt32(_assetBytes, sectionIndex + 4) + _DAT1Offset;
                }
            }
            return -1;
        }

        // Get the header bytes of any asset (all the bytes before 1TAD)
        //------------------------------------------------------------------------------------------
        private byte[] GetAssetHeader()
        {
            if (_DAT1Offset == -1)
            {
                return null;
            }

            return _assetBytes.Take(_DAT1Offset).ToArray();
        }
    }
}
