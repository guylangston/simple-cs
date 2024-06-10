var f = () => Console.WriteLine("a");
f += () => Console.WriteLine("b");
f += () => Console.WriteLine("c");
f();

Action ff = () => Console.WriteLine("1");
// ff += Console.WriteLine("2");
// ^^^ error CS0029: Cannot implicitly convert type 'void' to 'System.Action'
ff();

// Output:
// a
// b
// c
// 1
