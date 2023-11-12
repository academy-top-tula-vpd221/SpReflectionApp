using System.Reflection;
using SpReflectionApp;


//Type typeEmployee = typeof(Employee);
//Type typeEmployee = Type.GetType("SpReflectionApp.Employee", false, true);
Employee bob = new Employee("Bob", 45);
Type typeEmployee = bob.GetType();

Console.WriteLine(typeEmployee);

foreach(var m in typeEmployee.GetMembers())
    Console.WriteLine($"{m.DeclaringType} {m.MemberType} {m.Name}");
Console.WriteLine();

foreach (var m in typeEmployee.GetMembers(BindingFlags.DeclaredOnly
    | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    Console.WriteLine($"{m.DeclaringType} {m.MemberType} {m.Name}");
Console.WriteLine();


foreach (var p in typeEmployee.GetProperties())
    Console.WriteLine(p.Name);
Console.WriteLine();

foreach (var f in typeEmployee.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    Console.WriteLine(f.Name);
Console.WriteLine();

foreach (var i in typeEmployee.GetInterfaces())
    Console.WriteLine(i.Name);
Console.WriteLine();

var work = typeEmployee.GetMethod("Work");
work.Invoke(bob, null);
Console.WriteLine(work.IsPublic);
Console.WriteLine(work.ReturnType);

Console.WriteLine();
var ageMult = typeEmployee.GetMethod("AgeMult");
var pars = ageMult.GetParameters();
foreach(var p in pars)
{
    Console.WriteLine(p.Name);
    Console.WriteLine(p.ParameterType);
    Console.WriteLine(p.HasDefaultValue);
    Console.WriteLine(p.DefaultValue);

    Console.WriteLine();
}
Console.WriteLine();

var ctors = typeEmployee.GetConstructors();

var ctorParams = typeEmployee.GetConstructor(new Type[] { typeof(string), typeof(int) });
var e = ctorParams.Invoke(new object[] { "Joe", 33 });

Console.WriteLine(e);


var ctorDefault = typeEmployee.GetConstructor(Type.EmptyTypes);
var eAnonim = ctorDefault.Invoke(new object[] {});

Console.WriteLine(eAnonim);

var nameProp = typeEmployee.GetProperty("Name");
nameProp.SetValue(eAnonim, "Tom");

var idField = typeEmployee.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
idField?.SetValue(eAnonim, 5);

Console.WriteLine(eAnonim);
