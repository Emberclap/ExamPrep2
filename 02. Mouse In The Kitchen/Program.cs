namespace _02._Mouse_In_The_Kitchen
{
    public class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                   .Split(",", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            int mauseRowIndex = 0;
            int mauseColIndex = 0;
            int chesseCount = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine()
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                    if (col[cols] == 'M')
                    {
                        mauseRowIndex = rows;
                        mauseColIndex = cols;
                    }
                    else if (col[cols] == 'C')
                    {
                        chesseCount++;
                    }
                }
            }
            string command = string.Empty;
            bool moreChesse = true;
            while ((command = Console.ReadLine()) != "danger" && moreChesse)
            {
                switch (command)
                {
                    case "up":
                        if (BoundaryCheck(mauseRowIndex - 1, mauseColIndex, matrix))
                        {
                            if (Obstacle(mauseRowIndex - 1, mauseColIndex, matrix))
                            {
                                matrix[mauseRowIndex, mauseColIndex] = '*';
                                mauseRowIndex--;
                            }
                        }
                        else { moreChesse = false; break; }

                        break;
                    case "down":
                        if (BoundaryCheck(mauseRowIndex + 1, mauseColIndex, matrix))
                        {
                            if (Obstacle(mauseRowIndex + 1, mauseColIndex, matrix))
                            {
                                matrix[mauseRowIndex, mauseColIndex] = '*';
                                mauseRowIndex++;
                            }
                        }
                        else { moreChesse = false; break; }
                        break;
                    case "right":
                        if (BoundaryCheck(mauseRowIndex, mauseColIndex + 1, matrix))
                        {
                            if (Obstacle(mauseRowIndex, mauseColIndex + 1, matrix))
                            {
                                matrix[mauseRowIndex, mauseColIndex] = '*';
                                mauseColIndex++;
                            }
                        }
                        else { moreChesse = false; break; }
                        break;
                    case "left":
                        if (BoundaryCheck(mauseRowIndex, mauseColIndex - 1, matrix))
                        {
                            if (Obstacle(mauseRowIndex, mauseColIndex - 1, matrix))
                            {
                                matrix[mauseRowIndex, mauseColIndex] = '*';
                                mauseColIndex--;
                            }
                        }
                        else { moreChesse = false; break; }
                        break;
                    
                }
                if (matrix[mauseRowIndex, mauseColIndex] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    matrix[mauseRowIndex, mauseColIndex] = 'M';
                    break;
                }
                else if (matrix[mauseRowIndex, mauseColIndex] == 'C')
                {
                    chesseCount--;
                    matrix[mauseRowIndex, mauseColIndex] = '*';
                    if (chesseCount == 0)
                    {
                        matrix[mauseRowIndex, mauseColIndex] = 'M';
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }
            }
            if (!moreChesse)
            {
                matrix[mauseRowIndex, mauseColIndex] = 'M';
                Console.WriteLine("No more cheese for tonight!");
            }
            if (command == "danger")
            {
                matrix[mauseRowIndex, mauseColIndex] = 'M';
                Console.WriteLine("Mouse will come back later!");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        public static bool BoundaryCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool Obstacle(int rowIndex, int colIndex, char[,] matrix)
        {
            if (matrix[rowIndex, colIndex] == '@')
            {
                return false;
            }
            else { return true; }
        }
       
    } 
}