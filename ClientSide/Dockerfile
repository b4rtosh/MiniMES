# use the official Node.js image
FROM node:lts-alpine as build-stage

# Set the working directory in the container
WORKDIR /app

COPY package*.json ./

RUN npm install
#copy the rest of the app
COPY . .

RUN npm run build

# nginx to serve static files
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist/ /usr/share/nginx/html
EXPOSE 80
# start nginx
CMD ["nginx", "-g", "daemon off;"]
