# .wwproj Format Explanation

The `.wwproj` format is a custom binary file format used to store a collection of `Asset` objects along with their associated strings. Each asset in this format contains several properties, and each asset can be associated with one or more strings. Here's an explanation of the structure of the `.wwproj` file format, based on the code snippets provided and the assumptions about how it works.

## Structure of the `.wwproj` Format:

### 1. Asset Data:
Each asset in the `.wwproj` file contains the following data:
- **Span**: A byte representing some form of categorization or grouping for the asset.
- **ID**: A `ulong` (unsigned long) unique identifier for the asset.
- **Name**: A `string` representing the name of the asset.
- **Archive**: A `string` representing the archive or source of the asset.
- **FullPath**: A `string` that contains the full path of the asset file, if available.
- **RefPath**: A `string` that is a reference path constructed from the `Span` and `ID` (e.g., `"{Span}/{ID}"`).
  
### 2. Associated String(s):
Each asset can be associated with one or more strings. These strings could be additional metadata or information about the asset, such as tags, descriptions, or file paths. The string is serialized along with the asset.

### 3. Dictionary-like Structure:
The `.wwproj` file stores assets in a dictionary-like structure where each asset is linked with its associated string(s).
- Two dictionaries are used in the code: `_replacedAssets` and `_addedAssets`. Both dictionaries have the asset (`Asset`) as the key and a `string` (or list of strings, if multiple) as the value.

### 4. File Format Breakdown:
The file is serialized in binary format using a `BinaryWriter`. Each entry in the file includes the asset's properties followed by the associated string(s).
- **Asset Properties**: `Span`, `ID`, `Name`, `Archive`, `FullPath`, and `RefPath`.
- **Associated String(s)**: A `string` that is added to the dictionary along with the asset.

## Example File Layout:
Let’s assume we have the following two assets:

1. **Asset 1**:
   - Span: `1`
   - ID: `1234567890ABCDEF`
   - Name: `"AssetOne"`
   - Archive: `"Archive1"`
   - FullPath: `"C:/Assets/AssetOne"`
   - RefPath: `"1/1234567890ABCDEF"`
   - Associated String: `"StringForAssetOne"`

2. **Asset 2**:
   - Span: `2`
   - ID: `FEDCBA0987654321`
   - Name: `"AssetTwo"`
   - Archive: `"Archive2"`
   - FullPath: `"C:/Assets/AssetTwo"`
   - RefPath: `"2/FEDCBA0987654321"`
   - Associated String: `"StringForAssetTwo"`

## Serialization Process:
- **For each asset**:
  - Write the `Span` (byte).
  - Write the `ID` (ulong).
  - Write the `Name` (string).
  - Write the `Archive` (string).
  - Write the `FullPath` (string), or an empty string if it's null.
  - Write the `RefPath` (string).
  - Write the associated string (or empty string if it's null).

The serialization process involves writing these data elements sequentially to the file, and the structure can be replicated for multiple assets, allowing the file to store many assets.

## Handling Multiple Entries with the Same Asset Key:
- If the same `Asset` (with identical `Span` and `ID`) appears multiple times in the file, each entry can have different associated strings. This allows multiple metadata or tags to be associated with a single asset.
- For this, the format may use a dictionary-like structure, storing the `Asset` as the key and a list of associated strings as the value.

## File Size and Efficiency:
- Binary serialization is efficient in terms of file size and reading/writing speed. Since assets and their associated strings are stored contiguously, reading the file involves minimal overhead.

## Loading the `.wwproj` File:
When you load the `.wwproj` file, the process will involve:
1. Opening the file using a `FileStream`.
2. Using a `BinaryReader` to read the serialized data back.
3. Rebuilding the dictionary (`_addedAssets` or `_replacedAssets`) by deserializing each asset entry and adding it back to the dictionary along with its associated string(s).

## Example of Deserialization:

The code for deserialization (`AddFromWWPROJ`) was already outlined. It reads each asset and string from the binary file and re-adds them to the appropriate dictionary.

## Summary of `.wwproj` Format:
1. **Assets**: Each asset is stored with its `Span`, `ID`, `Name`, `Archive`, `FullPath`, and `RefPath`.
2. **Associated Strings**: Each asset can have one or more associated strings (metadata).
3. **Dictionary Structure**: Each asset is linked to a string (or list of strings) in either the `_replacedAssets` or `_addedAssets` dictionary.
4. **Binary Format**: The file is serialized in binary for efficiency, with data written sequentially.
5. **Supports Multiple Entries per Asset**: The format supports storing multiple strings for the same asset if needed.

This is a compact and efficient way to store and load asset data along with associate
