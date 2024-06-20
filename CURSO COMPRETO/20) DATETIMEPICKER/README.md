# DATETIMEPICKER
O `DateTimePicker` é um controle em Windows Forms que permite aos usuários selecionar datas e horas de forma intuitiva, facilitando a entrada e manipulação de dados de data e hora em suas aplicações. Ele fornece uma interface de calendário ou dropdown que simplifica a escolha de datas e pode ser configurado para exibir apenas data, apenas hora ou ambos.

## Configuração Básica do `DateTimePicker`
Para utilizar o `DateTimePicker` em um projeto Windows Forms, siga os passos abaixo para configurá-lo e integrá-lo ao seu formulário:

1. **Adicionar `DateTimePicker` ao Formulário**

   - No Visual Studio, abra ou crie um novo projeto Windows Forms.
   - Arraste e solte um controle `DateTimePicker` da janela `Toolbox` para o formulário (`Form1`).

2. **Configurar Propriedades Básicas**

   - Selecione o `DateTimePicker` no formulário e configure suas propriedades no painel de propriedades (`Properties`):
     - **Format**: Escolha entre `Short`, `Long`, `Time`, `Custom` para definir como a data e/ou hora será exibida.
     - **CustomFormat**: Se `Format` for `Custom`, você pode especificar um formato personalizado de exibição de data e/ou hora usando códigos de formato como `dd/MM/yyyy` para data ou `HH:mm:ss` para hora.
     - **ShowUpDown**: Define se o controle exibe setas para cima e para baixo para navegação rápida.
     - **Value**: Define o valor inicial do `DateTimePicker`.

3. **Manipular Eventos**

   - O `DateTimePicker` oferece alguns eventos úteis, como `ValueChanged`, que é disparado quando o valor selecionado é alterado. Você pode manipular esse evento para responder a alterações na seleção da data/hora pelo usuário.

   ```csharp
   private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
   {
       // Exemplo de ação ao alterar a data/hora selecionada
       MessageBox.Show("Nova data selecionada: " + dateTimePicker1.Value.ToShortDateString());
   }
   ```

4. **Executar o Projeto**

   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar a aplicação e interagir com o `DateTimePicker`.

## Exemplos de Uso
```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Configurações básicas do DateTimePicker
        dateTimePicker1.Format = DateTimePickerFormat.Short;
        dateTimePicker1.Value = DateTime.Today;
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Nova data selecionada: " + dateTimePicker1.Value.ToShortDateString());
    }
}
```

## Exemplo com Formato Personalizado
```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Configurações avançadas do DateTimePicker
        dateTimePicker1.Format = DateTimePickerFormat.Custom;
        dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        dateTimePicker1.ShowUpDown = true;
        dateTimePicker1.Value = DateTime.Now;
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show("Nova data selecionada: " + dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss"));
    }
}
```

## Considerações Finais
O `DateTimePicker` é uma ferramenta essencial para entrada de dados de data e hora em aplicações Windows Forms, oferecendo uma maneira intuitiva e conveniente para os usuários selecionarem datas e horas. Ao explorar suas propriedades e eventos, você pode personalizar facilmente o comportamento do controle para atender às necessidades específicas do seu projeto, melhorando assim a experiência do usuário com relação à manipulação de datas e horas.