# SYSINFO
A classe `SystemInformation` em Windows Forms fornece informações sobre o sistema operacional e o ambiente de trabalho do computador. Esses dados podem ser utilizados para adaptar a interface do usuário e o comportamento do aplicativo de acordo com as especificidades do sistema onde ele está sendo executado.

Aqui está um exemplo de como usar a classe `SystemInformation` para exibir informações do sistema em um formulário do Windows Forms:

## Exemplo de Uso da Classe SystemInformation
```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

public class SysInfoForm : Form
{
    private TextBox infoTextBox;

    public SysInfoForm()
    {
        InitializeComponents();
        DisplaySystemInformation();
    }

    private void InitializeComponents()
    {
        infoTextBox = new TextBox();
        infoTextBox.Multiline = true;
        infoTextBox.ScrollBars = ScrollBars.Vertical;
        infoTextBox.Dock = DockStyle.Fill;

        this.Controls.Add(infoTextBox);
        this.Text = "Informações do Sistema";
        this.Size = new Size(600, 400);
    }

    private void DisplaySystemInformation()
    {
        infoTextBox.AppendText($"Sistema Operacional: {SystemInformation.OSVersion}\r\n");
        infoTextBox.AppendText($"Versão do Sistema Operacional: {SystemInformation.OSVersion}\r\n");
        infoTextBox.AppendText($"Nome do Computador: {SystemInformation.ComputerName}\r\n");
        infoTextBox.AppendText($"Usuário Atual: {SystemInformation.UserName}\r\n");
        infoTextBox.AppendText($"Número de Monitores: {SystemInformation.MonitorCount}\r\n");
        infoTextBox.AppendText($"Tamanho da Tela Principal: {SystemInformation.PrimaryMonitorSize}\r\n");
        infoTextBox.AppendText($"Tamanho da Área de Trabalho: {SystemInformation.WorkingArea}\r\n");
        infoTextBox.AppendText($"Diretório do Sistema: {SystemInformation.GetFolderPath(Environment.SpecialFolder.System)}\r\n");
        infoTextBox.AppendText($"Diretório de Programas: {SystemInformation.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\r\n");
        infoTextBox.AppendText($"Diretório de Documentos: {SystemInformation.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\r\n");
        infoTextBox.AppendText($"Largura da Barra de Rolagem Vertical: {SystemInformation.VerticalScrollBarWidth}\r\n");
        infoTextBox.AppendText($"Altura da Barra de Rolagem Horizontal: {SystemInformation.HorizontalScrollBarHeight}\r\n");
        infoTextBox.AppendText($"Modo de Exibição de Alto Contraste: {SystemInformation.HighContrast}\r\n");
        infoTextBox.AppendText($"Número de Botões do Mouse: {SystemInformation.MouseButtons}\r\n");
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SysInfoForm());
    }
}
```

## Explicação do Código
1. **Inicialização do Formulário**: O formulário `SysInfoForm` é criado com um `TextBox` multiline para exibir as informações do sistema.

2. **Método DisplaySystemInformation**: Este método usa várias propriedades da classe `SystemInformation` para obter informações do sistema e exibi-las no `TextBox`.

3. **Propriedades Utilizadas**:
   - `SystemInformation.OSVersion`: Obtém a versão do sistema operacional.
   - `SystemInformation.ComputerName`: Obtém o nome do computador.
   - `SystemInformation.UserName`: Obtém o nome do usuário atual.
   - `SystemInformation.MonitorCount`: Obtém o número de monitores conectados.
   - `SystemInformation.PrimaryMonitorSize`: Obtém o tamanho do monitor principal.
   - `SystemInformation.WorkingArea`: Obtém a área de trabalho disponível no monitor principal.
   - `SystemInformation.GetFolderPath(Environment.SpecialFolder)`: Obtém o caminho de diretórios especiais como o sistema, programas, documentos etc.
   - `SystemInformation.VerticalScrollBarWidth`: Obtém a largura da barra de rolagem vertical padrão.
   - `SystemInformation.HorizontalScrollBarHeight`: Obtém a altura da barra de rolagem horizontal padrão.
   - `SystemInformation.HighContrast`: Indica se o modo de alto contraste está ativado.
   - `SystemInformation.MouseButtons`: Obtém o número de botões do mouse.

## Conclusão
A classe `SystemInformation` é uma ferramenta poderosa para obter detalhes sobre o sistema onde a aplicação está sendo executada. Isso permite que os desenvolvedores criem aplicativos mais adaptáveis e conscientes do ambiente, melhorando a experiência do usuário e garantindo a compatibilidade com diferentes configurações de sistema.