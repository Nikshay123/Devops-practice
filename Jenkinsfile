pipeline {
    agent any

    environment {
        PROJECT_DIR = 'Devops_practice' // Adjust if needed
        DOCKER_IMAGE_NAME = 'nikshay7891/devops-practice' // Update with your Docker Hub username
        DOCKER_TAG = 'latest'
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Nikshay123/Devops-practice.git'
            }
        }

        stage('Restore') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet build --configuration Release --no-restore'
                }
            }
        }

        stage('Test') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet test --no-restore --verbosity normal'
                }
            }
        }

        stage('Publish') {
            steps {
                dir(env.PROJECT_DIR) {
                    sh 'dotnet publish --configuration Release --output ./publish --no-restore'
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                dir(env.PROJECT_DIR) {
                    script {
                        sh "docker build -t ${env.DOCKER_IMAGE_NAME}:${env.DOCKER_TAG} ."
                    }
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    sh "docker login -u nikshay7891 -p qwertyuiop"
                    sh "docker push ${env.DOCKER_IMAGE_NAME}:${env.DOCKER_TAG}"
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    sh "docker run -d -p 8081:80 --name devops-practice-container ${env.DOCKER_IMAGE_NAME}:${env.DOCKER_TAG}"
                }
            }
        }
    }

    post {
        always {
            echo "Pipeline execution completed."
        }
        success {
            echo "Pipeline executed successfully."
        }
        failure {
            echo "Pipeline failed!"
        }
    }
}
