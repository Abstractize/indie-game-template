FROM unityci/editor:ubuntu-2021.3.2f1-webgl-1.0.1 AS builder

ARG UNITY_EMAIL
ARG UNITY_PASSWORD
ARG UNITY_SERIAL

ARG TARGET=WebGL

USER root
# Copy Unity Project
COPY . /src/
WORKDIR /src/

# Authenticate
RUN ["/bin/bash", "-c", "unity-editor -quit -batchmode -username $UNITY_EMAIL -password $UNITY_PASSWORD -serial $UNITY_SERIAL"]
# Compile Unity Project
RUN ["/bin/bash", "-c", "unity-editor -batchmode -stackTraceLogType Full -accept-apiupdate -nographics -projectPath /src/ -buildTarget $TARGET -quit -logFile /Logs/Editor.log"]
# Return License
RUN ["/bin/bash", "-c", "unity-editor -quit -batchmode -returnlicense -username $UNITY_EMAIL -password $UNITY_PASSWORD"]
RUN ls

FROM nginx:latest
#COPY ./nginx/nginx.conf /etc/nginx/conf.d/default.conf
# Copy Compiled Files
COPY --from=builder /src/Build/ /usr/share/nginx/html/