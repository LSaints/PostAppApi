FROM nginx:latest

RUN rm /etc/nginx/conf.d/default.conf

COPY configs/nginx.conf /etc/nginx/nginx.conf
COPY certs/cert.crt /etc/nginx/cert.crt
COPY certs/key.key /etc/nginx/key.key
