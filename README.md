# KeyTermsToChecklistConverter
Convert keyterms (tab-delimited Unicode .txt) to Xbench checklist

* **Requirements:** .NET Framework 4.5

# Description 
This application is designed to convert a tab-delimited text file into an ApSIC Xbench 3.0 checklist.

If your input file is an Excel, save the file as Unicode text file. It must contain at least two columns.

# Interface fields
1. **Input file**. A 2-column tab-delimited Unicode text file. 
2. **Source Term Options** and **Target Term Options**. Selected parameters will be applied to all checklist items.
3. **Key Terms Mismatch Mode**. When enabled, the checklist item will search for all segments that contain the source temrs but do not contain the target term. However, when disabled, the item will display all segments that contain source and target terms.
4. **Category**. Xbench allows you to add categories to checklists items. In this way, you can check only a specific checklist category items when running QA.
5. **Search mode**. There are two search modes available: simple and regular expressions. By default, the selected value is simple.

# Cases of use

1. Key terms file. The **Key Terms Mismatch Mode** check box must be enabled. When running QA in Xbench, checklist items will display those segments that contain a source term which has not been translated properly.
2. Checking that a source term has been translated in a specific way. Disable the **Key Terms Mismatch Mode** check box. For instance, you want to check that "file" has been translated as "fichero" but should be "archivo".
3. Search for source terms. If you want to find segments with a specific source term. The input file should only contain the source term and leave the target term empty.
4. Search for target terms. If you want to find segments with a specific source term. The input file should only contain the target term and leave the source term empty. In fact, this can be useful to locate incorrect wordss that been introduced but are not detected as misspelling when checking spelling. For instance, you may type "loca" instead of "local".

In cases 3 and 4, if the application detects that only the source or target term column contains text, it will create the checklist entry correctly. It does not matter whether the **Key Terms Mismatch Mode** is enabled or not.

The application supports multiple source and target terms. Enter the term at the first or second column in the following way:

```
| term1 | term2 | term3
```
Insert a vertical bar (|) as the first character followed by a space. Then insert space + vertical bar + space between terms.

