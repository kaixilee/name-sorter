# name-sorter
![](https://media.giphy.com/media/PDh7vdu40CnhS/giphy.gif?cid=790b7611m6g2yje7pxc05qyoyiu6kg8secumkanuwin0fwnt&ep=v1_gifs_search&rid=giphy.gif&ct=g)
## Overview
`name-sorter` is a console application that reads a list of names from a specified file, 
sorts the names by last name and then by given names, and writes the sorted names to an output file. 
The names to sort must have at least one given name, and up to three given names.
The sorted names are also printed to the console.

## Project Structure
The project is divided into two main parts:

**NameSorter:**
This is the main project containing the core functionality of the application.

**NameSorter.Tests:**
This project contains the unit tests for the application.

## Usage
To run the program, use the following command:

```sh
dotnet run --project NameSorter <file-path>
```
Replace `<file-path>` with the path to the file containing the names to be sorted.

### Example
```sh
dotnet run --project NameSorter ./unsorted-names-list.txt
```

## Testing
To run the tests, use the following command:

```sh
dotnet test
```
This will execute all the tests in the project and display the results.