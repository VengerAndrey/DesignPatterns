using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteArticles(new ScientificWriter());
            Console.WriteLine();
            WriteArticles(new ThrillerWriter());
        }

        static void WriteArticles(ArticleWriter writer)
        {
            Director director = new Director(writer);

            director.WriteFullArticle();
            writer.GetArticle().Print();

            director.WriteEmptyArticle();
            writer.GetArticle().Print();
            
            director.WriteUntitledArticle();
            writer.GetArticle().Print();
        }
    }

    class Article
    {
        public string Title { set; private get; } = "Unknown title";
        public string Author { set; private get; } = "Unknown author";
        public string Theme { set; private get; } = "Unknown theme";
        public string Content { set; private get; } = "Unknown content";
        public int Pages { set; private get; }

        public void Print()
        {
            Console.WriteLine($"Article \"{Title}\"");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Theme: {Theme}");
            Console.WriteLine(Content);
            Console.WriteLine($"Total pages: {Pages}");
            Console.WriteLine();
        }
    }

    abstract class ArticleWriter
    {
        protected Article article = new Article();

        public abstract void SetTitle();
        public abstract void SetAuthor();
        public abstract void SetTheme();
        public abstract void SetContent();
        public abstract void SetPages();

        public void Reset()
        {
            article = new Article();
        }

        public Article GetArticle()
        {
            var temp = article;
            Reset();
            return temp;
        }
    }

    class ScientificWriter : ArticleWriter
    {
        public override void SetTitle()
        {
            article.Title = "Scientific title";
        }

        public override void SetAuthor()
        {
            article.Author = "Azimov";
        }

        public override void SetTheme()
        {
            article.Theme = "Scientific research";
        }

        public override void SetContent()
        {
            article.Content = "A long time ago in a galaxy far far away...";
        }

        public override void SetPages()
        {
            article.Pages = 100;
        }
    }

    class ThrillerWriter : ArticleWriter
    {
        public override void SetTitle()
        {
            article.Title = "Thrilling title";
        }

        public override void SetAuthor()
        {
            article.Author = "King";
        }

        public override void SetTheme()
        {
            article.Theme = "Scary story";
        }

        public override void SetContent()
        {
            article.Content = "The clown-killer is living near you...";
        }

        public override void SetPages()
        {
            article.Pages = 20;
        }
    }

    class Director
    {
        private ArticleWriter writer;

        public Director(ArticleWriter writer)
        {
            this.writer = writer;
        }

        public void WriteFullArticle()
        {
            writer.SetTitle();
            writer.SetAuthor();
            writer.SetTheme();
            writer.SetContent();
            writer.SetPages();
        }

        public void WriteEmptyArticle()
        {
            writer.SetTitle();
            writer.SetAuthor();
            writer.SetTheme();
        }

        public void WriteUntitledArticle()
        {
            writer.SetAuthor();
            writer.SetTheme();
            writer.SetContent();
            writer.SetPages();
        }
    }
}
