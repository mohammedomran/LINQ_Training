using LinqProject.Models;
using LinqProject.MyLinq;

List<Employee> Managers = new List<Employee>()
{
    new Employee { Id = 0, Name = "Omran", JoinDate=2021 },
    new Employee { Id = 2, Name = "Ali", JoinDate=2005 },
    new Employee { Id = 2, Name = "George", JoinDate=2019 }
};
List<Employee> Sales = new List<Employee>();


// using the built-in GetEnumerator to loop through lists
IEnumerator<Employee> enumerator = Managers.GetEnumerator();
while (enumerator.MoveNext())
    Console.WriteLine(enumerator.Current.Name);

Console.WriteLine("#################");

// using simple extension methods
Console.WriteLine(Managers.CountItems());
Console.WriteLine(Managers.GetFirst().Name);
Console.WriteLine(Managers.GetLast().Name);

Console.WriteLine("#################");

// lambda expressions history
// 1- named methods appear but it was hard to define alot of them
// 2- delegates appear to write inline methods but senthax was bad
// 3- lambda expressions appear to refactor delegates code

// func & predicates were a way to simplify working with delegates "last param is the return type"
Func<int, int, int> GetSum = (x, y) => { return x + y; };
Console.WriteLine(GetSum(5, 3));

Func<int, bool> GetResult = x => x>5;
Console.WriteLine(GetResult(8));

Console.WriteLine("#################");

// custome filter using func and extension methods

var filteredManagers = Managers.Filter(x => x.JoinDate > 2010);
foreach (var manager in filteredManagers)
{
    Console.WriteLine(manager.JoinDate);
}


