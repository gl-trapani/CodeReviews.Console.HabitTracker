using HabitTracker;
using HabitTracker.Repositories;
using HabitTracker.UserInterface;

var connection = Config.ConnectDb();


var exerciseRepo = new ExerciseRepo(connection);
var waterRepo = new WaterRepo(connection);
var homeworkRepo = new HomeworkRepo(connection);

var habitMenu = new HabitMenu();
var deleteMenu = new DeleteMenu(exerciseRepo, waterRepo, homeworkRepo, habitMenu);
var selectMenu = new SelectMenu(exerciseRepo, waterRepo, homeworkRepo, habitMenu);
var insertMenu = new InsertMenu(exerciseRepo, waterRepo, homeworkRepo, habitMenu);
var updateMenu = new UpdateMenu(exerciseRepo, waterRepo, homeworkRepo, habitMenu);
var mainMenu = new MainMenu(insertMenu, selectMenu, deleteMenu, updateMenu);

while (true)
{
    mainMenu.DoJob();
}