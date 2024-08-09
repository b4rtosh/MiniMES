# use the official Node.js image
FROM node:16-alpine

# Set the working directory in the container
WORKDIR /app

COPY package*.json ./

RUN npm install
#copy the rest of the app
COPY . .

RUN npm run build

# nginx to serve static files
FROM nginx:alpine
COPY --from=0 /app/dist/ /usr/share/nginx/html
EXPOSE 5174

# start nginx
CMD ["nginx", "-g", "daemon off;"]