# SystemZero-Traits-Patterns

This is a library containing my traits patterns. Much like the gang of four original set of design patterns, this is an attempt to fill
in missing design patterns for the new traits style of programing.
https://en.wikipedia.org/wiki/Trait_(computer_programming)
This library builds up from fundemental logic design, and tries to take incremental steps for functionality.
Start with IData, a Data trait adds the logic for data, not showing access to the data, jut that the data exists. Then ITake and IGive cover the concepts of giving and taking data, they do not indecate that the data is stored, just that it can be taken. ISet and IGet indecate the the logic is stored, and together for a Hold or IHold. In combination with INotify IProcess IRespond IModify main more emergent behaviors and patterns emerge, and even lead to Behavior patterns.
Please feel free to ask me any questions, and please take note of the licensing to help fight off the AI overlords and protect the human need of logic.
