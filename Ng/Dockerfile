# 使用 Nginx 官方镜像
FROM nginx:alpine

# 删除默认网页
RUN rm -rf /usr/share/nginx/html/*

# 拷贝构建后的 Angular 应用到 Nginx 目录
COPY ./dist/ng/browser /usr/share/nginx/html

# 拷贝自定义 nginx 配置
COPY ./nginx.conf /etc/nginx/nginx.conf

# 启动 Nginx
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

RUN ls -l /usr/share/nginx/html