FROM openjdk:11-jdk-slim

WORKDIR /app

COPY . .

RUN chmod +x ./mvnw

RUN ./mvnw clean package -DskipTests

RUN find /app/target -name "*.jar" -type f -exec cp {} /app/app.jar \;

EXPOSE 9050

CMD ["java", "-jar", "/app/app.jar"]
