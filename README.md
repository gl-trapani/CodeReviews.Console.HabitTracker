# Console Habit Logger
Console based CRUD application to track habits.
## Given Requirements:
___
- [x] Log occurrences of habits
- [x] Habits are tracked by quantity
- [x] Users need to input date to insert habit
- [x] Application uses a local sqlite database
- [x] Database and tables are created on startup
- [x] Users should be able to insert, delete, update and view their habits

## Features
___
- SQLite database connection
  - The program uses a SQLite db connection to store and read information.
  - If no database exists, or the correct table does not exist they will be created on program start.
- Console UI
- CRUD DB functions
  - From the main menu users can Create, Read, Update or Delete entries for whichever date they want, entered in MM/DD/YYYY format.
  - Input is validated.

## Challenges
___
- I used OOP and probably made the app more complex than it needed to be.
- I am very uncertain about the architecture of OOP applications.
  - What needs to be a Class?
  - Where does this Method fit?
  - Should this Class have an Interface or Parent Class?
- There is a lot of repeated code that is only slightly different. I am unsure if I followed the DRY-principle correctly.
- I dont think I understand the use and implementation of Exceptions yet.

## Lessons Learned
___
- Plan before you code!
- Use the Readme as a project log.
- Do unit testing.
- Find out what unit testing is.
