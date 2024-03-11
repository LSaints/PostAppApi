# PostApp API

A PostApp API é uma aplicação desenvolvida em .NET Core que fornece uma interface robusta para publicações de texto e criação de grupos. Essa API é projetada para oferecer uma experiência segura e escalável, incorporando autenticação JWT para garantir a segurança dos dados e das interações dos usuários.

## Principais recursos:

- **Autenticação JWT**: A segurança é prioridade na PostApp API. Utilizando autenticação JSON Web Tokens (JWT), garantimos que apenas usuários autorizados possam acessar as funcionalidades da API.
  
- **Publicações de Texto**: Os usuários podem criar, visualizar, editar e excluir publicações de texto, facilitando o compartilhamento de informações e interações dentro da plataforma.

- **Criação de Grupos**: Além das publicações individuais, os usuários podem criar e gerenciar grupos temáticos para compartilhar conteúdo específico com membros selecionados.

- **Testes Unitários com Xunit**: Para assegurar a confiabilidade e o desempenho da aplicação, foram implementados testes unitários utilizando Xunit. Isso garante que cada parte da API seja testada de forma isolada e eficiente.

- **Docker e Docker Compose**: A PostApp API é implantada em contêineres Docker, o que simplifica a implantação e a manutenção em diferentes ambientes. O Docker Compose é utilizado para orquestrar a execução de vários contêineres e garantir uma integração perfeita entre eles.

- **Monitoramento com Prometheus e Grafana**: A saúde da API é monitorada em tempo real através do Prometheus, que exporta métricas importantes. Essas métricas são visualizadas em um dashboard intuitivo criado com Grafana, permitindo uma análise detalhada do desempenho da aplicação.

- **Integração Contínua com Jenkins**: A implementação de integração contínua é realizada utilizando Jenkins. Isso permite automatizar o processo de build, testes e implantação, garantindo a qualidade e consistência do código em cada etapa do desenvolvimento.

## Tecnologias Utilizadas:

- .NET Core
- Xunit
- MySQL
- Docker
- Docker Compose
- JSON Web Tokens (JWT)
- Prometheus
- Grafana
- Jenkins

A PostApp API é uma solução completa e poderosa para gerenciar publicações de texto e grupos, oferecendo segurança, desempenho e escalabilidade. Com uma arquitetura moderna e tecnologias avançadas, é uma escolha ideal para aplicações web e móveis que exigem funcionalidades de compartilhamento de conteúdo.
