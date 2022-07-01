// books.toscrape.com

// Scraping exercise:
// STEP 1. Get all links
// STEP 2. Process all links to get book details
// STEP 3. Export CSV

// get the page
// get an object of that page - this is parsing
// get exactly the information you are looking for - querying
// (we'll be looking for booktitle and price)
// CSV (in real life it'll be a db)


using HtmlAgilityPack;

string url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html";

HtmlWeb web = new HtmlWeb();

// load connects to the site and converts it into an HtmlDocument object (it's kind of like XML) which is ready to be queried
HtmlDocument doc = web.Load(url);
// DocumentNode gets you the complete document
Console.Write(doc.DocumentNode.InnerText);







