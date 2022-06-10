using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ToolCollection
    {
        // lists history of all borrowed tools
        // uses single array as it is very simple to sort rearranging 1 tool by addition)
        // using a simple sort every entry is expected to be more efficient than using a
        //      more complex sort each time the DisplayTop3 method is called
        public BorrowToken[] ToolBorrowHistory { get; set; }

        // list of all tools in library
        public Tool[][][] ToolLibrary { get; set; }

        // initiate singleton
        private static ToolCollection tools;


        // return singleton
        public static ToolCollection Tools
        {
            get { return tools; }
        }

        // initial singleton set-up and return singleton
        public static ToolCollection InitializeToolCollection()
        {
            if (tools == null)
                tools = new ToolCollection(100);

            return tools;
        }

        private ToolCollection(int size)
        {
            ToolBorrowHistory = new BorrowToken[size];
            ToolLibrary = new Tool[9][][];
        }


        // search tool by tool name
        public Tool SearchTool(string toolName)
        {
            string toolNameLower = toolName.ToLower();

            for (int i = 0; i < ToolLibrary.Length; i++)
            {
                for (int j = 0; j < ToolLibrary[i].Length; j++)
                {
                    for (int k = 0; k < ToolLibrary[i][j].Length; k++)
                    {
                        if (ToolLibrary[i][j][k]?.Name.ToLower() == toolNameLower)
                            return ToolLibrary[i][j][k];
                    }
                }
            }

            return null;
        }


        // completely remove tool from library
        public void RemoveTool(Tool tool)
        {
            int categoryIndex;
            int typeIndex;

            for (categoryIndex = 0; categoryIndex < ToolLibrary.Length; categoryIndex++)
            {
                if (ToolLibrary[categoryIndex][0][0]?.Category == tool.Category)
                    break;
            }

            for (typeIndex = 0; typeIndex < ToolLibrary[categoryIndex].Length; typeIndex++)
            {
                if (ToolLibrary[categoryIndex][typeIndex][0]?.Type == tool.Type)
                    break;
            }

            for (int i = 0; i < ToolLibrary[categoryIndex][typeIndex].Length; i++)
            {
                if (ToolLibrary[categoryIndex][typeIndex][i]?.Name == tool.Name)
                {
                    ToolLibrary[categoryIndex][typeIndex][i] = null;
                    break;
                }
            }
        }


        public void AddToHistory(string toolName)
        {
            int index;

            for (index = 0; index < ToolBorrowHistory.Length && ToolBorrowHistory[index] != null; index++)
            {
                if (ToolBorrowHistory[index].Name == toolName)
                {
                    ToolBorrowHistory[index].Count++;
                    SortHistory(index);
                    return;
                }
            }

            // add tool to history
            ToolBorrowHistory[index] = new BorrowToken(toolName);

            SortHistory(index);
        }


        private void SortHistory(int index)
        {
            // selection sort is used as only one object is being ordered

            for (int i = index; i > 0; i--)
            {
                if (ToolBorrowHistory[i].Count > ToolBorrowHistory[i - 1].Count)
                {
                    var temp = ToolBorrowHistory[i];
                    ToolBorrowHistory[i] = ToolBorrowHistory[i - 1];
                    ToolBorrowHistory[i - 1] = temp;
                }
                else
                    return;
            }
        }

        // populate existing tool data
        public void PopulateToolData()
        {
            string[] toolCategories = new string[] {"Gardening tools", "Flooring tools", "Fencing tools", "Measuring tools",
                "Cleaning tools", "Painting tools", "Electronic tools", "Electricity tools", "Automotive tools"};

            string[] gardeningTools = new string[] { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools" };

            string[] flooringTools = new string[] { "Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };

            string[] fencingTools = new string[] { "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };

            string[] measuringTools = new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };

            string[] cleaningTools = new string[] { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };

            string[] paintingTools = new string[] { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };

            string[] electronicTools = new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };

            string[] electricityTools = new string[] { "Test Equipment", "Safety Equipment", "Basic Hand tools", "Circuit Protection", "Cable Tools" };

            string[] automotiveTools = new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

            string[][] toolTypes = new string[][] {gardeningTools, flooringTools, fencingTools, measuringTools, cleaningTools, paintingTools,
                electronicTools, electricityTools, automotiveTools };

            
            // populate dummy tool data
            for (int i = 0; i < ToolLibrary.Length; i++)
            {
                ToolLibrary[i] = new Tool[toolTypes[i].Length][];

                for (int j = 0; j < toolTypes[i].Length; j++)
                {
                    // assumed that 10 possible different tools of each tool type is sufficient
                    ToolLibrary[i][j] = new Tool[10];

                    for (int k = 0; k < 3; k++)
                    {
                        //create 3 example tools for each tool type
                        ToolLibrary[i][j][k] = new Tool(toolCategories[i], toolTypes[i][j], $"{toolTypes[i][j]} example {k + 1}", 5);

                        Console.WriteLine("new Tool : " + ToolLibrary[i][j][k].Name);
                    }
                }
            }

            Console.WriteLine("\n\t Above are some dummy tools. The names can be used as reference. \n");
            Console.ReadKey();
        }
    }
}
