using System;
using System.Collections.Generic;

namespace Task1
{
    //task1
    struct Article
    {
        int productCode;
        String productName;
        public float productPrice;

        //field enum from task5
        ArticleType articleType;

        //constructor 
        public Article(int productCode, String productName, float productPrice, ArticleType articleType)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.productPrice = productPrice;
            this.articleType = articleType;
        }

        public override string ToString()
        {
            return "{productName: " + productName + "productCode: "+ productCode + ", price: " + productPrice + "}";
        }
    }

    //task2
    struct Client
    {
        static int clientNumbers = 0;
        int clientCode;
        String name;
        String adress;
        String telephone;
        int ordersNum;
        public static int totalOrdersAmount;

        //method for adding number of orders for every client and total number of orders 
        public void addOrder()
        {
            ordersNum++;
            totalOrdersAmount++;
        }

        //client type enum from task6
        public ClientType clientType;

        // constructor
        public Client(string name, string adress, string telephone, ClientType clientType)
        {
            // autoincrement clientCode
            this.clientCode = clientNumbers++;
            this.name=name;
            this.adress=adress;
            this.telephone=telephone;

            //when creating a new client number of orders == 0
            this.ordersNum = 0 ;
            this.clientType=clientType;
        }

        public override string ToString()
        {
            return  "{ " + clientCode + ", " +  name + ", "+  adress + ", " + telephone + ", "+ clientType + ", orders : " + ordersNum + " }";
        }
    }

    // task3
    struct RequestItem
    {
        public Article comodity;
        public int numberOfUnits;

        // constructor
        public RequestItem(Article comodity, int numberOfUnits)
        {
            this.comodity=comodity;
            this.numberOfUnits=numberOfUnits;
        }
    }

    //task 4
    struct Request 
    {
        //field for autoincrement
        static int totalOrders = 0;
        int orderCode;
        Client client;
        DateTime orderDate;
        List<RequestItem> orderedProducts;
        float orderPrice;

        // payment type enum from task7
        PayType payType;


        public Request(ref Client client, List<RequestItem> orderedProducts, DateTime dateTime, PayType payType)
        {

            this.orderCode = totalOrders++;
            this.client = client;
            this.orderedProducts = orderedProducts;
            this.orderDate = dateTime;
            this.payType = payType;

            // adding +1 order to client
            client.addOrder();

            // calculating order price 
            this.orderPrice = 0;
            foreach (RequestItem requestItem in orderedProducts)
            {
                this.orderPrice += requestItem.numberOfUnits * requestItem.comodity.productPrice;
            }
        }

        public override string ToString()
        {
            return "{ OrderCode: " + orderCode + ", Client: " + client + ", date: " + orderDate + ", price: " + orderPrice + " }";
        }
    }

    //task5 
    enum ArticleType
    {
        drinks,
        food,
        nonFood
    }

    //task6
    enum ClientType
    {
        low,
        medium,
        high
    }

    //task7
    enum PayType
    {
        card,
        cash,
        transfer, 
        tickets
    }
    

    class Program
    {
        static void Main(string[] args)
        {

            // creating 3 Article 
            Article article1 = new Article(1, "water", 5.5f, ArticleType.drinks);
            Article article2 = new Article(2, "bread", 4.5f, ArticleType.food);
            Article article3 = new Article(3, "soap", 3, ArticleType.nonFood);

            // creating 3 Clients
            Client client1 = new Client("John","Miami","555333123",ClientType.low);
            Client client2 = new Client("Brad","NY","444333123",ClientType.medium);
            Client client3 = new Client("George","Seatle","222333123",ClientType.high);

            //output all clients
            Console.WriteLine("Clients");
            Console.WriteLine(client1);
            Console.WriteLine(client2);
            Console.WriteLine(client3);

            //creating 3 RequestItem
            RequestItem requestItem1 = new RequestItem(article1,3);
            RequestItem requestItem2 = new RequestItem(article2,5);
            RequestItem requestItem3 = new RequestItem(article3,7);

            //creating a list of prducts
            List<RequestItem> requestItems = new List<RequestItem>();
            requestItems.Add(requestItem1);

            //creating first Request
            Request request1 = new Request(ref client1, requestItems, DateTime.Now,PayType.card);

            // adding one more request item to requestItems list
            requestItems.Add(requestItem2);

            //creating second Request
            Request request2 = new Request(ref client2, requestItems, DateTime.Now,PayType.cash);

            // adding one more request item to requestItems list
            requestItems.Add(requestItem3);

            //creating third Request
            Request request3 = new Request(ref client3, requestItems, DateTime.Now,PayType.transfer);

            //creating list of requests
            List<Request> requests = new List<Request>();
            requests.Add(request1);
            requests.Add(request2);
            requests.Add(request3);

            //adding new RequestItem , new request 
            requestItems.Add(new RequestItem(article1, 10));

            requests.Add(new Request(ref client2, requestItems, DateTime.Now, PayType.card));
            
            //removing first requestItem from requestItems list
            requestItems.RemoveAt(0);

            //adding one more request
            requests.Add(new Request(ref client1, requestItems, DateTime.Now, PayType.card));

            //output all requests
            Console.WriteLine("Requests ");
            foreach (Request request in requests)
            {
                Console.WriteLine(request);
            }

            //output all clients
            Console.WriteLine("Clients");
            Console.WriteLine(client1);
            Console.WriteLine(client2);
            Console.WriteLine(client3);

            // output total number of orders
            Console.WriteLine("Total number of orders : " + Client.totalOrdersAmount);

        }
    }
}
