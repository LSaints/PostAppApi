# Use uma imagem base adequada para o Prometheus
FROM prom/prometheus:latest

# Copie o arquivo de configuração prometheus.yml para o diretório de configuração do Prometheus na imagem
COPY configs/prometheus.yml /etc/prometheus/prometheus.yml

VOLUME  "/data"
# Exponha a porta do Prometheus (se necessário)
EXPOSE 9090

# Execute o Prometheus com o arquivo de configuração que você copiou
CMD ["--config.file=/etc/prometheus/prometheus.yml"]
