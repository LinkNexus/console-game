PWD := $(shell pwd)

build: ## Builds the project
	@echo "Building the project..."
	dotnet build

run: ## Runs the project
	@echo "Running the project..."
	@echo ${PWD}
	hyprctl dispatch exec "[workspace special:console-game]" 'kitty -e bash -c "cd ${PWD} && dotnet run --project app"'
