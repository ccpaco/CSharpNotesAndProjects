 //switch case might help
        
        //3 types of discount tags
        // type 0 - discounted price, (item only) 15
        // type 1 - fixed percentage discount from retail price - 0.15
        // type 2 - fixed discount, fixed amount off retail - 15
        

        // products come in as nested arrays in [price, tags or empty]
        // (not quite arrays) lists
        // Empty = null ? possible word hint 
        

        // products = ['price', 'tag 1', 'tag 2']
        // discounts = ['tag', 'type', 'amount']
        

        // return int totalAmount for ALL listed products, discounted to priv member pricing
        
/*


STDIN                    Function
-----                    --------
2              →         products[] size n = 2
3              →         products[i] size m = 3
10 sale january-sale →   products = [['10', 'sale', 'january-sale'], ['200', 'sale', 'EMPTY']]
200 sale EMPTY

2              →         discounts[] size d = 2
3              →         discounts[j] size = 3 (always)
sale 0 10      →         discounts = [['sale', '0', '10'], ['january-sale', '1', '10']]
january-sale 1 10


the output : 19

explanation

========================================================================================================================
Approach 1 :

starting val = 0 ;

starting val = p[i[0]];


// public static int findLowestPrice(List<List<string>> products, List<List<string>> discounts)

//      for (int i = 0; i <= uBound0; i++) {
//          for (int j = 0; j <= uBound1; j++) {
//             string res = array[i, j];
//             Console.WriteLine(res);
//          }
//       }

//       for (int i = 0; i < products.Count; i++)
//       {
//           for(int j = 0; j <= products.Count - 1; j++ )
//           {
//               Console.WriteLine(products[i][j])
//           }
//       }


// 4 / 15 cases passed 

public static int findLowestPrice(List<List<string>> products, List<List<string>> discounts)
    {
            int totalPrice = 0;
            for(int i = 0; i < products.Count; i++)
            {
                for(int j = 0; j < products[i].Count; j++ )
                {
                    Console.WriteLine(products[i][j]);
                    bool success = Int32.TryParse(products[i][j], out int number);
                    totalPrice += number;
                }
            }
            return totalPrice;
    }

// 4 / 15 cases passed, sep method for Products

public static int findLowestPrice(List<List<string>> products, List<List<string>> discounts)
    {
        // if discounts 
        // handleDisc(product[][])
        // else if no disounts? 
        return handleProd(products);
    }
    
    public static int handleProd(List<List<string>> prods)
    {
        int totalPrice = 0;
        for(int i = 0; i < prods.Count; i++)
        {
            for(int j = 0; j < prods[i].Count; j++ )
            {
                Console.WriteLine(prods[i][j]);
                bool success = Int32.TryParse(prods[i][j], out int number);
                if (!success) Console.WriteLine("Special : " + prods[i][j]);
                    // this is the case where there are discounts

                totalPrice += number;
            }
        }
        return totalPrice;
    }
    
    // public static int handleDisc(List<List<string>> discounts)
    // {
        
    //     int bestDisc;
    //     for(int i = 0; i < disc.Count; i ++)
    //     {
    //         for(int j = 0; j < prods[i].Count; j++)
    //         {
                
    //         }
    //     }
        
    //     return bestDisc;
    // }

*/

