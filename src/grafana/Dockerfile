# Use a imagem base do Grafana
FROM grafana/grafana:latest

# Copie o arquivo de configuração personalizado para dentro do contêiner
COPY configs/grafana.ini /etc/grafana/grafana.ini

# Exponha a porta do Grafana
EXPOSE 3000

# Comando padrão para iniciar o Grafana
CMD ["grafana-server", "--config=/etc/grafana/grafana.ini"]
