using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class MapWizard : EditorWindow
{
    private VisualElement root;
    private SliderInt widthField;
    private SliderInt heightField;
    private Toggle isHex;

    private int minWidth = 3;
    private int maxWidth = 21;

    private int minHeight = 3;
    private int maxHeight = 15;

    private Map.CellType[][] cellTypes;
    private Button[][] buttons;

    [MenuItem("Wizards/Map")]
    static void CreateWizard()
    {
        MapWizard wnd = GetWindow<MapWizard>();
        wnd.titleContent = new GUIContent("Map Creation Wizard");
    }

    public void CreateGUI()
    {
        root = rootVisualElement;

        root.Add(DimensionGUI());

        Box empty = new Box();
        empty.style.marginBottom = 5;
        empty.style.marginTop = 5;
        empty.style.marginLeft = 5;
        empty.style.marginRight = 5;
        empty.style.flexGrow = 1;
        root.Add(empty);

        Button saveButton = new Button(CreateMap);
        saveButton.text = "Save Map";
        saveButton.style.marginLeft = 5;
        saveButton.style.marginRight = 5;
        saveButton.style.marginBottom = 5;
        root.Add(saveButton);

        UpdateGridGUI();
    }

    private Box DimensionGUI()
    {

        Box dimensions = new Box();
        dimensions.style.marginBottom = 5;
        dimensions.style.marginTop = 5;
        dimensions.style.marginLeft = 5;
        dimensions.style.marginRight = 5;

        widthField = new SliderInt("Width", minWidth, maxWidth);
        widthField.value = 15;
        widthField.showInputField = true;
        widthField.RegisterValueChangedCallback(x => UpdateGridGUI());
        dimensions.Add(widthField);

        heightField = new SliderInt("Height", minHeight, maxHeight);
        heightField.value = 9;
        heightField.showInputField = true;
        heightField.RegisterValueChangedCallback(x => UpdateGridGUI());
        dimensions.Add(heightField);

        isHex = new Toggle("Hexagonal Map");
        isHex.value = true;
        isHex.RegisterValueChangedCallback(x => UpdateGridGUI());
        dimensions.Add(isHex);

        return dimensions;
    }

    private void UpdateGridGUI()
    {
        root.RemoveAt(root.childCount - 2);
        root.Insert(root.childCount - 1, GridGUI());
    }

    private Box GridGUI()
    {
        int width = widthField.value;
        int height = heightField.value;

        Box grid = new Box();
        int heightGrid = 500;
        int emptySpace = heightGrid / (2 * (height + 1));
        grid.style.height = 500;
        if (isHex.value)
        {
            grid.style.marginTop = emptySpace;
        }
        else
        {
            grid.style.marginTop = 5;
        }
        grid.style.marginBottom = 5;
        grid.style.marginLeft = 5;
        grid.style.marginRight = 5;
        grid.style.flexGrow = 1;

        cellTypes = new Map.CellType[height][];
        buttons = new Button[height][];
        for (int i = 0; i < height; i++)
        {
            cellTypes[i] = new Map.CellType[width];
            buttons[i] = new Button[width];
            VisualElement row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.flexGrow = 1;
            for (int j = 0; j < width; j++)
            {
                int x = i;
                int y = j;
                Button button = new Button(() => { ToggleButton(x, y); });
                buttons[i][j] = button;
                cellTypes[i][j] = Map.CellType.Tower;

                if (isHex.value && y % 2 == 1) button.style.top = -emptySpace;
                button.style.borderBottomLeftRadius = 0;
                button.style.borderBottomRightRadius = 0;
                button.style.borderTopLeftRadius = 0;
                button.style.borderTopRightRadius = 0;
                button.style.marginLeft = 1;
                button.style.marginRight = 1;
                button.style.marginBottom = 1;
                button.style.marginTop = 1;
                button.style.flexGrow = 1;
                button.style.backgroundColor = Color.gray;
                row.Add(button);
            }
            grid.Add(row);
        }

        return grid;
    }

    private void ToggleButton(int i, int j)
    {
        switch (cellTypes[i][j])
        {
            case Map.CellType.Tower:
                cellTypes[i][j] = Map.CellType.Path;
                buttons[i][j].style.backgroundColor = Color.yellow;
                break;
            case Map.CellType.Path:
                cellTypes[i][j] = Map.CellType.Start;
                buttons[i][j].style.backgroundColor = Color.green;
                break;
            case Map.CellType.Start:
                cellTypes[i][j] = Map.CellType.Finish;
                buttons[i][j].style.backgroundColor = Color.red;
                break;
            case Map.CellType.Finish:
                cellTypes[i][j] = Map.CellType.Cell;
                buttons[i][j].style.backgroundColor = Color.black;
                break;
            case Map.CellType.Cell:
            default:
                cellTypes[i][j] = Map.CellType.Tower;
                buttons[i][j].style.backgroundColor = Color.gray;
                break;
        }
    }

    private void CreateMap()
    {
        Map map = CreateInstance<Map>();
        map.grid = new Map.MapRow[cellTypes.Length];
        for (int i = 0; i < cellTypes.Length; i++)
        {
            map.grid[i] = new Map.MapRow();
            map.grid[i].row = new Map.CellType[cellTypes[0].Length];
            for (int j = 0; j < cellTypes[0].Length; j++)
            {
                map.grid[i].row[j] = cellTypes[cellTypes.Length - i - 1][j];
            }
        }
        AssetDatabase.CreateAsset(map, "Assets/Maps/New Map.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Close();
    }
}
