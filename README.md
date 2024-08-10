# ClipboardManager
`ClipboardManager` is a simple WPF (Windows Presentation Foundation) application built using C#. It allows users to manage and interact with their clipboard history. The application automatically tracks text copied to the clipboard and stores it in a list, enabling users to search, copy, or delete items from the history.

## Features
- **Automatic Clipboard Tracking**: The application automatically detects and saves text copied to the clipboard.
- **Search Functionality**: Users can search through their clipboard history to quickly find specific text.
- **Copy to Clipboard**: Users can copy any item from the history back to the clipboard with a single click.
- **Delete History Items**: Users can delete specific items from the clipboard history.
- **Clear History**: Users can clear the entire clipboard history with a single click.

## Prerequisites
- **Visual Studio**: Ensure you have Visual Studio installed on your system.
- **.NET Framework**: This application targets the .NET Framework. Make sure the .NET Framework is installed on your machine.

## Project Setup
1. **Clone the repository**:
   git clone https://github.com/RubavathyImmanuvel/ClipboardManager.git
2. **Open the Project**:
   Open Visual Studio.<br>
   Navigate to the cloned repository folder and open the ClipboardManager.sln solution file.
3. **Build and Run**:
   Build the project by clicking on Build -> Build Solution.<br>
   Run the application by clicking on Debug -> Start Debugging or pressing F5.
   
## Usage
- **Tracking Clipboard Content**:
  The application automatically tracks any text copied to the clipboard and adds it to the list displayed in the main window.
- **Search**:
  Enter text in the search box to filter the clipboard history. The list will update to show only the items that contain the search text.
- **Copy to Clipboard**:
  Select an item from the list and click the "Copy" button to copy it to the clipboard. You can also double-click an item to copy it.
- **Delete Items**:
  Select an item and click the "Delete" button to remove it from the clipboard history.
- **Clear History**:
  Click the "Clear History" button to remove all items from the clipboard history.

## Contributing
Contributions are welcome! If you have any ideas for improving the app, feel free to fork the repository and create a pull request, or open an issue to discuss potential changes.
