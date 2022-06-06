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
        //  more complex sort each time the DisplayTop3 method is called
        public Tool[] ToolBorrowHistory { get; set; }
        
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
            ToolBorrowHistory = new Tool[size];
            ToolLibrary = new Tool[9][][];
        }

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

            for (int i = 0; i < ToolLibrary.Length; i++)
            {
                ToolLibrary[i] = new Tool[toolTypes[i].Length][];

                for (int j = 0; j < toolTypes[i].Length; j++)
                {
                    // assumed that 10 possible different tools of each tool type is sufficient
                    ToolLibrary[i][j] = new Tool[10];

                    for (int k = 0; k < 3; k++)
                    {
                        // don't need to create any tools yet

                        //create 3 example tools for each tool type
                        ToolLibrary[i][j][k] = new Tool(toolCategories[i], toolTypes[i][j], $"{toolTypes[i][j]} example {k + 1}", 5);

                        //Console.Write("Tool category    : " + ToolLibrary[i][j][k].Category);
                        //Console.WriteLine("Tool type    : " + ToolLibrary[i][j][k].Type);
                        Console.WriteLine("new Tool : " + ToolLibrary[i][j][k].Name);
                    }
                }
            }
        }

        // search tool by tool name
        public Tool SearchTool(string toolName)
        {
            for (int i = 0; i < ToolLibrary.Length && ToolLibrary[i][0][0] != null; i++)
            {
                for (int j = 0; j < ToolLibrary[i].Length && ToolLibrary[i][j][0] != null; j++)
                {
                    for (int k = 0; k < ToolLibrary[i][j].Length && ToolLibrary[i][j][k] != null; k++)
                    {
                        if(ToolLibrary[i][j][k].Name == toolName)
                        {
                            Console.WriteLine("returning : " + ToolLibrary[i][j][k].Name);
                            return ToolLibrary[i][j][k];
                        }
                    }
                }
            }

            Console.WriteLine("Tool not found in library.");
            return null;
        }

        // TODO: search tool by tool category, type and name
        public static Tool SearchTool(string toolCat, string toolType, string toolName)
        {
            return null;
        }
    }
}
