using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorksCore
{
    public class AssetUtilities
    {
        //------------------------------------------------------------------------------------------
        public static int Find1TADMarker(byte[] data)
        {
            byte[] marker = { 0x31, 0x54, 0x41, 0x44 };

            for (int i = 0; i <= data.Length - marker.Length; i++)
            {
                if (data.Skip(i).Take(marker.Length).SequenceEqual(marker))
                    return i;
            }
            return -1;
        }

        //------------------------------------------------------------------------------------------
        public enum AssetType
        {
            Atmosphere,
            Texture,
            Unknown
        }

        public static AssetType CheckAssetType(byte[] asset)
        {
            int DAT1Offset = Find1TADMarker(asset);

            if (DAT1Offset == -1)
            {
                return AssetType.Unknown; // If the marker is not found
            }

            byte[] magicBytes = asset.Skip(DAT1Offset + 4).Take(4).ToArray();
            Array.Reverse(magicBytes);

            uint typeValue = BitConverter.ToUInt32(magicBytes, 0);

            switch (typeValue)
            {
                case 0x4FBCF482:
                    return AssetType.Atmosphere;
                default:
                    return AssetType.Unknown;
            }
        }

        //------------------------------------------------------------------------------------------
        public static byte[] GetAssetSection(byte[] asset, uint section)
        {
            int index = Find1TADMarker(asset);
            if (index == -1) return null;

            int offset = index + 16; // Skip "1TAD", MAGIC, Asset Size, and Number of Sections
            int numSections = BitConverter.ToInt32(asset, index + 12);

            for (int i = 0; i < numSections; i++)
            {
                int sectionIndex = offset + (i * 12);
                uint sectionID = BitConverter.ToUInt32(asset, sectionIndex);
                if (sectionID == section)
                {
                    int sectionOffset = BitConverter.ToInt32(asset, sectionIndex + 4) + index;
                    int sectionSize = BitConverter.ToInt32(asset, sectionIndex + 8);

                    return asset.Skip(sectionOffset).Take(sectionSize).ToArray();
                }
            }
            return null;
        }

        public static int GetAssetSectionOffset(byte[] asset, uint section)
        {
            int index = Find1TADMarker(asset);
            if (index == -1) return -1;

            int offset = index + 16;
            int numSections = BitConverter.ToInt32(asset, index + 12);

            for (int i = 0; i < numSections; i++)
            {
                int sectionIndex = offset + (i * 12);
                uint sectionID = BitConverter.ToUInt32(asset, sectionIndex);
                if (sectionID == section)
                {
                    int sectionOffset = BitConverter.ToInt32(asset, sectionIndex + 4) + index;
                    return sectionOffset;
                }
            }
            return -1;
        }


        public static byte[] GetAssetHeader(byte[] asset)
        {
            int index = Find1TADMarker(asset);

            if (index == -1 || index < 36)
            {
                // If "1TAD" is not found, or there are fewer than 36 bytes before it
                return null;
            }

            // Return the bytes before "1TAD"
            return asset.Take(index).ToArray();
        }
    }
}
