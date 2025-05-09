FROM openjdk:11-jdk-slim

RUN apt-get update && apt-get install -y maven

WORKDIR /app

COPY . .

RUN mvn clean package -DskipTests

RUN find /app/target -name "*.jar" -type f -exec cp {} /app/app.jar \;

EXPOSE 9000

CMD ["java", "-jar", "/app/app.jar"]
