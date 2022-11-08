using EmissaoNotaApp.Application.Models;
using EmissaoNotaApp.Application.Daos;

Console.WriteLine("Digite 1 para inserir um produto.");
Console.WriteLine("Digite 2 para remover um produto.");
Console.WriteLine("Digite 3 para consultar um produto.");
Console.WriteLine("Digite 4 para listar todos os produtos.");
Console.WriteLine("Digite 5 para alterar um produto.");
var option = Console.ReadLine();

if (option == "1")
{
    await InsertProduct();
}
else if (option == "2")
{
    await DeleteProduct();
}
else if (option == "3")
{
    await GetProduct();
}
else if (option == "4")
{
    await GetAllProducts();
}
else if (option == "5")
{
    await UpdateProduct();
}

async Task InsertProduct()
{
    var produto = new Produto();
    Console.WriteLine("Digite o código do produto");
    produto.Codigo = Console.ReadLine();
    Console.WriteLine("Digite a descrição do produto");
    produto.Descricao = Console.ReadLine();

    var produtoDao = new ProdutoDao();
    await produtoDao.Insert(produto);
    Console.WriteLine("Produto inserido com sucesso.");
    Console.ReadKey();
}

async Task DeleteProduct()
{ 
    Console.WriteLine("Digite o Id do produto");
    var id = long.Parse(Console.ReadLine());

    var produtoDao = new ProdutoDao();
    await produtoDao.Delete(id);
    Console.WriteLine("Produto excluído com sucesso.");
    Console.ReadKey();

}

async Task GetProduct()
{
    Console.WriteLine("Digite o Id do produto");
    var id = long.Parse(Console.ReadLine());

    var produtoDao = new ProdutoDao();
    var produto = await produtoDao.Get(id);
    Console.WriteLine($"O ID do produto é: {produto.Id}");
    Console.WriteLine($"O código do produto é: {produto.Codigo}");
    Console.WriteLine($"A descrição do produto é: {produto.Descricao}");
    Console.ReadKey();
}

async Task GetAllProducts()
{
    

    var produtoDao = new ProdutoDao();
    var produtos = await produtoDao.GetAll();
    foreach (var produto in produtos)
    {
        Console.WriteLine($"O ID do produto é: {produto.Id}");
        Console.WriteLine($"O código do produto é: {produto.Codigo}");
        Console.WriteLine($"A descrição do produto é: {produto.Descricao}");
    }
    Console.ReadKey();
}

async Task UpdateProduct()
{
    Console.WriteLine("Digite a Id do produto a ser alterado");
    var id = long.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo código do produto");
    var novoCodigo = Console.ReadLine();
    Console.WriteLine("Digite a nova descrição do produto");
    var novaDescricao = Console.ReadLine();

    var produtoDao = new ProdutoDao();
    await produtoDao.Update(id , novoCodigo, novaDescricao);

    Console.WriteLine("Produto alterado com sucesso");
    Console.ReadKey();
}