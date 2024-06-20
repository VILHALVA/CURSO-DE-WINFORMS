# NOTIFYICON
Em C#, o `NotifyIcon` é um controle útil do Windows Forms que permite aos desenvolvedores exibir ícones na bandeja do sistema (systray) e interagir com eles através de eventos e menu de contexto. É comumente utilizado para criar aplicativos que rodam em segundo plano e precisam notificar os usuários ou oferecer acesso rápido a funcionalidades sem ocupar espaço na barra de tarefas principal. Aqui está um guia básico sobre como usar o `NotifyIcon` em seu projeto:

## Passos para Utilizar o NotifyIcon em C#
### 1. **Adicionar o NotifyIcon ao Formulário:**
Primeiro, abra seu projeto no Visual Studio e siga os passos abaixo:

- **Arrastar e Soltar:** No Visual Studio, abra o formulário onde deseja adicionar o `NotifyIcon`. Na janela Toolbox, procure por `NotifyIcon` e arraste-o para o formulário.

- **Configurações Iniciais:** Após adicionar o `NotifyIcon`, você pode configurar suas propriedades principais diretamente no Visual Studio, como `Icon`, `Text`, `Visible`, entre outras.

### 2. **Configuração via Código:**
Para configurar o `NotifyIcon` via código, você pode fazer isso no construtor do formulário ou em algum ponto durante a inicialização do aplicativo:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private NotifyIcon notifyIcon;

    public Form1()
    {
        InitializeComponent();
        InitializeNotifyIcon();
    }

    private void InitializeNotifyIcon()
    {
        notifyIcon = new NotifyIcon();
        notifyIcon.Icon = SystemIcons.Information; // Define o ícone exibido na bandeja
        notifyIcon.Text = "Meu Aplicativo"; // Texto de tooltip ao passar o mouse sobre o ícone
        notifyIcon.Visible = true; // Torna o ícone visível na bandeja do sistema

        // Definindo um menu de contexto
        ContextMenu contextMenu = new ContextMenu();
        MenuItem menuItemOpen = new MenuItem("Abrir", OpenMenuItem_Click);
        MenuItem menuItemExit = new MenuItem("Sair", ExitMenuItem_Click);
        contextMenu.MenuItems.Add(menuItemOpen);
        contextMenu.MenuItems.Add(menuItemExit);

        notifyIcon.ContextMenu = contextMenu;

        // Adicionar um evento de clique duplo no ícone
        notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
    }

    private void NotifyIcon_DoubleClick(object sender, EventArgs e)
    {
        // Lógica para o que acontece quando o usuário clica duas vezes no ícone
        MessageBox.Show("Ícone do NotifyIcon foi clicado duas vezes.");
    }

    private void OpenMenuItem_Click(object sender, EventArgs e)
    {
        // Lógica para abrir o aplicativo quando o item de menu "Abrir" é clicado
        MessageBox.Show("Abrir o aplicativo...");
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        // Lógica para fechar o aplicativo quando o item de menu "Sair" é clicado
        notifyIcon.Visible = false; // Esconde o ícone da bandeja do sistema
        Application.Exit(); // Fecha o aplicativo
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Garante que o ícone seja removido da bandeja do sistema quando o aplicativo for fechado
        notifyIcon.Visible = false;
        base.OnFormClosing(e);
    }
}
```

### 3. **Funcionalidades do NotifyIcon:**
- **Ícone e Texto:** Configure o ícone que será exibido na bandeja do sistema e um texto de tooltip para fornecer informações adicionais ao usuário.
- **Menu de Contexto:** Adicione um menu de contexto ao `NotifyIcon` para permitir que os usuários executem ações específicas ao clicar com o botão direito no ícone.
- **Eventos:** Manipule eventos como `DoubleClick` para reagir às interações do usuário com o ícone na bandeja do sistema.
- **Visibilidade:** Controle a visibilidade do `NotifyIcon` conforme necessário durante a execução do aplicativo.

### 4. **Considerações Finais:**
O `NotifyIcon` é uma ferramenta poderosa para melhorar a usabilidade e acessibilidade de aplicativos que precisam operar em segundo plano, fornecendo aos usuários acesso rápido e notificações discretas diretamente da bandeja do sistema. Certifique-se de gerenciar corretamente a visibilidade e os eventos associados ao `NotifyIcon` para uma experiência de usuário consistente e intuitiva.