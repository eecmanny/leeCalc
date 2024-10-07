List<string> todoList = new List<string>();
//List<string> todoList = new List<string> { "Test1", "Test2", "Test3", "Test4", "Test5" };
bool exitProgram = false;


//Intro to program
Console.WriteLine("Welcome to Lee Company Engineering Calculator!");
Console.WriteLine("");

//why is this true by default
//reference bool to exit while loop but doesn't manipulate data
while (!exitProgram)
{
    Console.WriteLine("");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("Type number to select calculation");
    Console.WriteLine("1: Formula title 1");
    Console.WriteLine("2: Formula title 2");
    Console.WriteLine("3: Formula title 3");
    Console.WriteLine("4: Formula title 4");
    Console.WriteLine("5: Formula title 5");
    Console.WriteLine("6: Formula title 6");

    string userMenuChoice = Console.ReadLine();

    //executes TodoMenuChoices method
    //Need to pass through 2 parameter to work
    string userPickedResults = TodoMenuChoices(userMenuChoice, todoList, ref exitProgram);
    // You need this to see what is returns from the switch statment 
    Console.WriteLine(userPickedResults);

}

//all the methods need to return strings
//reference bool to exit while loop but doesn't manipulate data
string TodoMenuChoices(string userPickedResults, List<string> todoList, ref bool exitProgram)
{
    switch (userPickedResults)
    {
        case "1":
            return SeeAllTodo(todoList);
        case "2":
            return AddTodo(todoList);
        case "3":
            return RemoveTodo(todoList);
        case "EXIT":
        case "exit":
        case "Exit":
            exitProgram = true;
            return Exit();
        default:
            return "Invalid option. Please choose S, A, R, or E.";
    }
}

//Todo Read fetch requests methods
string SeeAllTodo(List<string> todoList)
{

    if (todoList.Count == 0)
    {
        return "There are no todos.";
    }
    //Empty string and 0 count to keep track of of Todos
    string todoResults = "";
    int todoCount = 0;
    foreach (string todo in todoList)
    {
        todoCount++;
        //todoResults keeps track of which todo and description, loops through and strings them together
        //\n put the next todo on the next console line
        todoResults += $"Todo {todoCount}: {todo}\n";

    }
    //return has to be on the outside of the for each loop so it can conintue looping without stopping until the end
    return todoResults;
}

//foreach loops through list for todos
//if statement makes sure no duplicates
string AddTodo(List<string> todoList)
{
    Console.WriteLine("Please add add a todo");
    string userAddTodo = Console.ReadLine();

    foreach (string todo in todoList)
    {
        if (todo == userAddTodo)
        {
            return "This todo already exists";
        }
    }
    todoList.Add(userAddTodo);
    Console.WriteLine($"{userAddTodo} was successfully  added.");
    return userAddTodo;
}


//This is a faster way of doing it because we aren't using a loop.
////The AddTodo method now uses todoList.Contains() to check if a todo already exists.
//string AddTodo(List<string> todoList)
//{
//    Console.WriteLine("Please add a todo");
//    string userAddTodo = Console.ReadLine();

//    if (todoList.Contains(userAddTodo))
//    {
//        return "This todo already exists.";
//    }

//    todoList.Add(userAddTodo);
//    return $"{userAddTodo} was successfully added.";
//}


string RemoveTodo(List<string> todoList)
{
    if (todoList.Count == 0)
    {
        return "Nothing to remove";
    }
    Console.WriteLine("Which todo number would you like to remove.");
    string userRemoveTodo = Console.ReadLine();
    int userRemoveTodoIndex = int.Parse(userRemoveTodo);
    // Validate the user's input to ensure it's within the valid range

    if (userRemoveTodoIndex < 1 || userRemoveTodoIndex > todoList.Count)
    {
        return "Invalid todo number.";
    }

    //The variable removedTodo stores the todo that is about to be removed,
    //ensuring that you still have access to it after it's removed from the list.
    //The subtraction of 1 from userRemoveTodoIndex converts the user's input (which is 1-based) to the list’s zero-based index.
    string removedTodo = todoList[userRemoveTodoIndex - 1];
    todoList.RemoveAt(userRemoveTodoIndex - 1);

    return $"Successfully removed {removedTodo}.";
}


string Exit()
{
    return "Exiting the program.";
}

Console.ReadKey();