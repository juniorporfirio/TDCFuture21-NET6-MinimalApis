
public record Talk(Guid Id,
[property: Required(ErrorMessage = "Please, input the title")] string Title,
[property: Required(ErrorMessage = "Please, input the name of speaker")] string Speaker,
string Trail);
